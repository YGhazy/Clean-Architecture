using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using CleanArchitecture.Infrastructure.Persistence.Data_context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly DatabaseContext _dbContext;
        public MovieRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Movie>> GetMoviesByGenre(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<Movie>> GetMoviesByGenre(int id)
        //{
        //    return await _dbContext.Movies
        //        .Where(m => m.GenreID == id).ToListAsync();
        //}

    }
}
