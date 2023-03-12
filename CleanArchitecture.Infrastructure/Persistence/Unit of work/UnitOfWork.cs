using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence.Data_context;

namespace CleanArchitecture.Infrastructure.Persistence.Unit_of_work
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
