using EZServiceLocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Webjet.Movies.Domain.Contracts.Services;
using Webjet.Movies.Domain.Entities;
using Webjet.Movies.IoC;

namespace Webjet.Movies.Tests
{
    [TestClass]
    public class GetMoviesTest
    {
        private IMovieService _service;

        public GetMoviesTest()
        {
            Bootstrap.Go();

            _service = ServiceLocator.Current.GetService<IMovieService>();
        }

        [TestMethod]
        public void GetMoviesList()
        {
            var movies = _service.GetMovies();

            Assert.IsTrue(movies.Count >= 6);
        }

        [TestMethod]
        public void GetMovieDetails()
        {
            var movie = new Movie()
            {
                Id = "cw2488496",
                Database = "cinemaworld"
            };

            var movies = _service.GetMovieDetails(new List<Movie>() { movie });

            Assert.IsTrue(movies.Count == 1);
            Assert.IsTrue(movies.First().Title == "Star Wars: The Force Awakens");
        }
    }
}
