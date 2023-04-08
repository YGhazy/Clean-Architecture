using CleanArchitecture.Domain.Enums;
using CleanArchitecture.Domain.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IAsyncRepository<TEntity>
        where TEntity : class

    {
        private readonly DbContext context;
        public DbSet<TEntity> dbSet;

        public BaseRepository(DbContext dbContext)
        {
            context = dbContext;
            dbSet = context.Set<TEntity>();

        }



        public virtual async Task<IQueryable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            int pageNumber = 0,
            int itemsPerPage = 0,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (!string.IsNullOrEmpty(includeProperties) && !string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!string.IsNullOrEmpty(includeProperty))
                    {
                        query = query.Include(includeProperty);
                    }
                }
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                if (pageNumber > 0 && itemsPerPage > 0)
                {
                    query = orderBy(query)
                        .Skip((pageNumber - 1) * itemsPerPage)
                        .Take(itemsPerPage);
                }
                else
                {
                    query = orderBy(query); ;
                }
            }
            else
            {
                if (pageNumber > 0 && itemsPerPage > 0)
                {
                    query = query
                        .Skip((pageNumber - 1) * itemsPerPage)
                        .Take(itemsPerPage);
                }
            }
            return await Task.Run(() =>
            {
                return query;
            });
        }

        public async Task<List<TEntity>> GetPageAsync<TKey>(int PageNumeber = 0, int PageSize = 0, Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TKey>> sortingExpression = null, SortDirection sortDir = SortDirection.Ascending, string includeProperties = "")
        {
            IQueryable<TEntity> query = context.Set<TEntity>();
            int skipCount = (PageNumeber - 1) * PageSize;

            if (filter != null)
                query = query.Where(filter);

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            switch (sortDir)
            {
                case SortDirection.Ascending:
                    if (skipCount == 0)
                        query = query.OrderBy<TEntity, TKey>(sortingExpression).Take(PageSize);
                    else
                        query = query.OrderBy<TEntity, TKey>(sortingExpression).Skip(skipCount).Take(PageSize);
                    break;
                case SortDirection.Descending:
                    if (skipCount == 0)
                        query = query.OrderByDescending<TEntity, TKey>(sortingExpression).Take(PageSize);
                    else
                        query = query.OrderByDescending<TEntity, TKey>(sortingExpression).Skip(skipCount).Take(PageSize);
                    break;
                default:
                    break;
            }
            return await query.AsNoTracking().ToListAsync();
        }
        public virtual async Task<IQueryable<TEntity>> GetIgnoreQueryFilterAsync(
           int pageNumber = 0,
           int itemsPerPage = 0,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = null)
        {

            IQueryable<TEntity> query = dbSet;

            if (!string.IsNullOrEmpty(includeProperties) && !string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!string.IsNullOrEmpty(includeProperty))
                    {
                        query = query.Include(includeProperty);
                    }
                }
            }

            query = query.IgnoreQueryFilters();

            if (orderBy != null)
            {
                if (pageNumber > 0 && itemsPerPage > 0)
                {
                    query = orderBy(query)
                        .Skip((pageNumber - 1) * itemsPerPage)
                        .Take(itemsPerPage);
                }
                else
                {
                    query = orderBy(query); ;
                }
            }
            else
            {
                if (pageNumber > 0 && itemsPerPage > 0)
                {
                    query = query
                        .Skip((pageNumber - 1) * itemsPerPage)
                        .Take(itemsPerPage);
                }
            }

            return await Task.Run(() =>
            {
                return query;
            });
        }

        public virtual async Task<TEntity> GetByIdAsync(params object[] id)
        {
            var item = await dbSet.FindAsync(id);
            //if (item != null && !item.IsDeleted)
            //{
            return item;
            //}
            //return null;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            //entity.CreatedOn = DateTime.UtcNow;
            var dbChangeTracker = await dbSet.AddAsync(entity);
            return dbChangeTracker.State == EntityState.Added ? dbChangeTracker.Entity : null;
        }

        public virtual async Task CreateRangeAsync(params TEntity[] entities)
        {
            //foreach (var entity in entities)
            //{
            //    entity.CreatedOn = DateTime.UtcNow;
            //}
            await dbSet.AddRangeAsync(entities);
        }

        public virtual async Task<bool> UpdateAsync(TEntity entityToUpdate)
        {
            return await Task.Run(() =>
            {
                //entityToUpdate.ModifiedOn = DateTime.UtcNow;
                var dbChangeTracker = dbSet.Update(entityToUpdate);
                return dbChangeTracker.State == EntityState.Modified;
            });
        }

        public virtual async Task<bool> RemoveAsync(TEntity entity)
        {
            return await Task.Run(() =>
            {
                if (entity != null)
                {

                    var dbChangeTracker = dbSet.Remove(entity);
                    return dbChangeTracker.State == EntityState.Deleted;

                }
                return false;
            });

        }

        public async Task<List<Dictionary<string, object>>> ExecuteStoredProcedure(string storedProcedureName, Dictionary<string, object> parameters = null)
        {
            return await Task.Run(() =>
            {

                List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
                string connectionString = context.Database.GetDbConnection().ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(storedProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(string.Format("@{0}", param.Key), param.Value));
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Dictionary<string, object> dic;
                string colName;
                object colData;
                foreach (DataRow row in dt.Rows)
                {
                    dic = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        var colNameCamelCase = col.ColumnName.ToCharArray();
                        colNameCamelCase[0] = colNameCamelCase[0].ToString().ToLower().ToCharArray()[0];
                        colName = new string(colNameCamelCase);
                        colData = row[col];
                        dic.Add(colName, colData);
                    }
                    result.Add(dic);
                }
                return result;
            });

        }
    }
}