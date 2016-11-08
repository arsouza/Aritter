using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Controllers;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Aritter.Infra.IoC.Providers;

namespace Aritter.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(config =>
            {
                config.Filters.Add(new Aritter.API.Seedwork.Filters.ErrorFilterAttribute());
            });

            ServiceProvider.Instance.DefaultScopedLifestyle = new AspNetRequestLifestyle();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(ServiceProvider.Instance.Container));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSimpleInjectorAspNetRequestScoping(ServiceProvider.Instance.Container);

            ServiceProvider.Instance.Container.RegisterMvcControllers(app);
            ServiceProvider.Instance.Container.Verify();

            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
