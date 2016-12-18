using System.Collections.Generic;
using Webjet.Movies.Domain.Entities;

namespace Webjet.Movies.Domain.Contracts.Repository
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies(string database);

        IEnumerable<Movie> GetMovieDetails(IList<Movie> movies);
    }
}
