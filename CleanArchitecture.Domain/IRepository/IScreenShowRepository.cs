using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.IRepository
{
    public interface IScreenShowRepository : IAsyncRepository<ScreenShow>
    {
        Task<IEnumerable<ScreenShow>> GetAllScreenShowsAsync();
        Task<ScreenShow> GetScreenShowByIdAsync(int id);
        Task<IEnumerable<ScreenShow>> GetScreenShowsByMovieIdAsync(int movieId);
        Task<IEnumerable<ScreenShow>> GetScreenShowsByDateAsync(DateTime date);
    }
}
