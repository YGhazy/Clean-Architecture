using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Unit_of_work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _dbContext.SaveChangesAsync() > 0;

            }
            catch (DbUpdateConcurrencyException ex)
            {
                // log message and enteries
            }
            catch (DbUpdateException ex)
            {
                // log message and enteries
            }
            catch (Exception ex)
            {
                // Log here.
            }
            return false;
        }
        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
