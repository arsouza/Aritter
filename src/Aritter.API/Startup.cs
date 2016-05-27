using Aritter.API;
using Aritter.Infra.Crosscutting.Adapter;
using Aritter.Infra.Crosscutting.Adapter.AutoMapper;
using Aritter.Infra.Crosscutting.Logging;
using Aritter.Infra.Crosscutting.Logging.NLog;
using Aritter.Infra.IoC.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System.Web.Http;

[assembly: OwinStartup(typeof(Startup))]

namespace Aritter.API
{
    public partial class Startup
    {
        private Container container = InstanceProvider.Instance.Container;

        public void Configuration(IAppBuilder app)
        {
            ConfigureFactories();

            var config = new HttpConfiguration();

            ConfigureDependencyResolver(config);

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            app.UseCors(CorsOptions.AllowAll);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            ConfigureFormatters(config);

            app.Use(async (context, next) =>
            {
                using (container.BeginExecutionContextScope())
                {
                    await next();
                }
            });

            ConfigureAuth(app);
            app.UseWebApi(config);
        }

        private void ConfigureDependencyResolver(HttpConfiguration config)
        {
            container.RegisterWebApiControllers(config);
            container.Verify();
            config.DependencyResolver = InstanceProvider.Instance.DependencyResolver;
        }

        private void ConfigureFactories()
        {
            LoggerFactory.SetCurrent(new NLogLoggerFactory());
            TypeAdapterFactory.SetCurrent(new AutoMapperTypeAdapterFactory());
        }

        private void ConfigureFormatters(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());
        }
    }
}
