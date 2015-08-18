using Aritter.Infra.IoC.Providers;
using Ninject.WebApi.DependencyResolver;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Aritter.API_
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			//DependencyProvider.Instance.Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			//DependencyProvider.Instance.Container.Verify();
			//GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(DependencyProvider.Instance.Container);

			GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(ServiceProvider.Instance.Kernel);

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
