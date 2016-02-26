using Aritter.Infra.IoC.Providers;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

namespace Aritter.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ServiceProvider.Instance.Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            ServiceProvider.Instance.Container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(ServiceProvider.Instance.Container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}