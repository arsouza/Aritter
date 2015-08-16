using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace Aritter.API
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.SuppressDefaultHostAuthentication();

			config.EnableCors();
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Formatters.Remove(config.Formatters.XmlFormatter);
			config.Formatters.JsonFormatter.Indent = true;
			config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}
	}
}
