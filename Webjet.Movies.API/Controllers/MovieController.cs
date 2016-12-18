using EZServiceLocation;
using System.Collections.Generic;
using System.Web.Http;
using Webjet.Movies.Domain.Contracts.Services;
using Webjet.Movies.Domain.Entities;

namespace Webjet.Movies.API.Controllers
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        private IMovieService _service;

        public MovieController()
        {
            _service = ServiceLocator.Current.GetService<IMovieService>();
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _service.GetMovies();
        }

        [HttpPost]
        public IEnumerable<Movie> GetMovieDetails(IList<Movie> movies)
        {
            return _service.GetMovieDetails(movies);
        }
    }
}