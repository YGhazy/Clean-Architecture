
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class ScreenRepository : BaseRepository<Screen>, IScreenRepository
    {
        private readonly DatabaseContext _dbContext;
        public ScreenRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
