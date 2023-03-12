using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IRepository
{
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetWhere(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] propertiesToUpdate);
        Task DeleteAsync(TEntity entity);
        Task<int> CountAsync();

    }
}
