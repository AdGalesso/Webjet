using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using Webjet.Movies.Domain.Contracts.Repository;
using Webjet.Movies.Domain.Entities;
using Newtonsoft.Json;
using System.Linq;

namespace Webjet.Movies.Repository.APIs
{
    public class MovieRepository : IMovieRepository
    {
        public IEnumerable<Movie> GetMovies(string database)
        {
            var content = get(database, string.Empty);

            var movies = JsonConvert.DeserializeObject<Dictionary<string, List<Movie>>>(content);

            return movies != null ? movies["Movies"] : Enumerable.Empty<Movie>();
        }

        public IEnumerable<Movie> GetMovieDetails(IList<Movie> movies)
        {
            var result = new List<Movie>();

            for (int i = 0; i < movies.Count; i++)
            {
                var movie = movies[i];

                var content = get(movie.Database, movie.Id);

                if (!string.IsNullOrEmpty(content))
                {
                    movie = JsonConvert.DeserializeObject<Movie>(content);

                    result.Add(movie);
                }
            }

            return result;
        }

        Func<string, string, string> get = (database, movieId) => {
            string content, api;

            if (string.IsNullOrEmpty(movieId))
                api = $"{ ConfigurationManager.AppSettings["WebjetAPI"] }/{ database }/movies";
            else
                api = $"{ ConfigurationManager.AppSettings["WebjetAPI"] }/{ database }/movie/{ movieId }";

            var client = new RestClient(api);
            var request = new RestRequest(Method.GET);

            client.AddDefaultHeader("x-access-token", ConfigurationManager.AppSettings["WebjetAPIToken"]);

            try
            {
                var response = client.Execute(request);

                content = response.Content;
            }
            catch
            {
                //Todo: Log somewhere
                content = string.Empty;
            }

            return content;
        };
    }
}