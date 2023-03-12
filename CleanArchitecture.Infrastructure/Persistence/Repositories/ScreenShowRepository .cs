using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class ScreenShowRepository : BaseRepository<ScreenShow>, IScreenShowRepository
    {
        private readonly DatabaseContext _dbContext;
        public ScreenShowRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ScreenShow>> GetAllScreenShowsAsync()
        {
            return await _dbContext.ScreenShows.ToListAsync();
        }

        public async Task<ScreenShow> GetScreenShowByIdAsync(int id)
        {
            return await _dbContext.ScreenShows.FindAsync(id);
        }

        public async Task<IEnumerable<ScreenShow>> GetScreenShowsByMovieIdAsync(int movieId)
        {
            return await _dbContext.ScreenShows.Where(ss => ss.Show.MovieId == movieId).ToListAsync();
        }

        public async Task<IEnumerable<ScreenShow>> GetScreenShowsByDateAsync(DateTime date)
        {
            return await _dbContext.ScreenShows.Where(ss => ss.Show.DateTime.Date == date.Date).ToListAsync();
        }
    }
}
