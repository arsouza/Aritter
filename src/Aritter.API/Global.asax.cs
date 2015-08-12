using Aritter.Infrastructure.Injection;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Aritter.API
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			DependencyProvider.Instance.Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			DependencyProvider.Instance.Container.Verify();
			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(DependencyProvider.Instance.Container);

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
	}
}
