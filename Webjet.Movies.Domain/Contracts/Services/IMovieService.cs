using System.Collections.Generic;
using Webjet.Movies.Domain.Entities;

namespace Webjet.Movies.Domain.Contracts.Services
{
    public interface IMovieService
    {
        IList<Movie> GetMovies();

        IList<Movie> GetMovieDetails(IList<Movie> movies);
    }
}
