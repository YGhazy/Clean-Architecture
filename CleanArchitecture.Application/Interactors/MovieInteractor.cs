using CleanArchitecture.Application.IInteractors;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interactors
{
    public class MovieInteractor : IMovieInteractor
    {
        private readonly IMovieRepository _movieRepository;

        public MovieInteractor(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAll();
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.AddAsync(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateAsync(movie);
        }

        public void DeleteMovie(Movie movie)
        {
            _movieRepository.DeleteAsync(movie);
        }
    }
}
