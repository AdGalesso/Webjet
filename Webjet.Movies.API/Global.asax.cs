using System.Web;
using System.Web.Http;
using Webjet.Movies.IoC;

namespace Webjet.Movies.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrap.Go();
        }
    }
}
