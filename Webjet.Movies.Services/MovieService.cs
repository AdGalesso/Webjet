using System.Collections.Generic;
using Webjet.Movies.Domain.Contracts.Repository;
using Webjet.Movies.Domain.Contracts.Services;
using Webjet.Movies.Domain.Entities;
using System.Linq;
using System;
using System.Configuration;

namespace Webjet.Movies.Services
{
    public class MovieService : IMovieService
    {
        private IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public IList<Movie> GetMovies()
        {
            var movies = new List<Movie>();
            var moviesDatabases = ConfigurationManager.AppSettings["MoviesDatabases"].Split(',');

            for (int i = 0; i < moviesDatabases.Length; i++)
            {
                var database = moviesDatabases[i].Trim();
                var result = _repository.GetMovies(database).ToList();

                result.ForEach(m => m.SetDatabase(database));
                movies.AddRange(result);
            }

            return movies.OrderBy(m => m.Year).ToList();
        }

        public IList<Movie> GetMovieDetails(IList<Movie> movies)
        {
            var result = _repository.GetMovieDetails(movies).ToList();

            result.ForEach(m => m.SetDatabase(movies.Single(mAux => m.Id == mAux.Id).Database));

            return result;
        }
    }
}
