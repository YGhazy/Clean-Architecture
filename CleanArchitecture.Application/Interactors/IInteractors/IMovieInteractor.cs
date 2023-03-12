using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IInteractors
{

    public interface IMovieInteractor
    {
        Task<Movie> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetAllMovies();
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);

    }
}
