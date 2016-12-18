using EZServiceLocation;
using Webjet.Movies.IoC.Map;

namespace Webjet.Movies.IoC
{
    public static class Bootstrap
    {
        public static void Go()
        {
            ServiceLocator.Current.LoadServiceMap<MovieMap>();
        }
    }
}
