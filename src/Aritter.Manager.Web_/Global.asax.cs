using Aritter.Manager.Infrastructure.Injection;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Aritter.Manager.Web
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			DependencyProvider.Instance.Container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			DependencyProvider.Instance.Container.RegisterMvcIntegratedFilterProvider();
			DependencyProvider.Instance.Container.Verify();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(DependencyProvider.Instance.Container));
		}
	}
}
