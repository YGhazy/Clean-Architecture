
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class TheaterRepository : BaseRepository<Theater>, ITheaterRepository
    {
        private readonly DatabaseContext _dbContext;
        public TheaterRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
