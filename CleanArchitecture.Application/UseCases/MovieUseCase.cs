using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.IInteractors;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.IUseCaes
{
    public class MovieUseCase : IMovieUseCase
    {
        private readonly IMovieInteractor _movieInteractor;

        public MovieUseCase(IMovieInteractor movieInteractor)
        { 
            _movieInteractor = movieInteractor;
        }

        //public Result<int> AddMovie(string title, string releaseYear, string summary)
        //{
        //    var movie = _movieFactory.Create(title, releaseYear, summary);
        //    if (string.IsNullOrWhiteSpace(movie.Title))
        //        return Result<int>.Fail("Invalid movie title");

        //    _movieInteractor.AddMovie(movie);
        //    return Result<int>.Ok(movie.Id);
        //}
    }
}


