using EZServiceLocation;
using Webjet.Movies.Domain.Contracts.Repository;
using Webjet.Movies.Domain.Contracts.Services;
using Webjet.Movies.Repository.APIs;
using Webjet.Movies.Services;

namespace Webjet.Movies.IoC.Map
{
    public class MovieMap : ServiceMap
    {
        public override void Load()
        {
            For<IMovieRepository>().Use<MovieRepository>();
            For<IMovieService>().Use<MovieService>(new ConstructorDependency(typeof(IMovieRepository)));
        }
    }
}