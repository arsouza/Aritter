using Aritter.API.Seedwork.Filters;
using Aritter.API.Seedwork.Security.Filters;
using Aritter.Infra.Cosscutting.Configuration;
using Aritter.Infra.IoC.Containers;
using Aritter.Security.Infra.Ioc.Containers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Generator;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aritter.Security.API
{
    public partial class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public ISimpleInjectorServiceContainer ServiceContainer { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            ServiceContainer = new SimpleInjectorServiceContainer();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(config =>
            {
                config.Filters.Add(new ErrorFilterAttribute());
            });

            // Add functionality to inject IOptions<T>
            services.AddOptions();

            // Add our Config object so it can be injected
            //services.Configure<ConnectionStringsSettings>(Configuration.GetSection("ConnectionStrings"));

            // Inject an implementation of ISwaggerProvider with defaulted settings applied
            services.AddSwaggerGen();

            services.ConfigureSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Aritter.Security.API.xml"));
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            // *If* you need access to generic IConfiguration this is **required**
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IServiceContainer>(ServiceContainer);
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(ServiceContainer.Container as Container));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSimpleInjectorAspNetRequestScoping(ServiceContainer.Container);

            ServiceContainer.Configure(app.ApplicationServices, container =>
            {
                container.Options.DefaultScopedLifestyle = new AspNetRequestLifestyle();
                container.Register<IConfiguration>(() => { return Configuration; }, Lifestyle.Scoped);
            });

            ServiceContainer.Container.RegisterMvcControllers(app);
            ServiceContainer.Container.Verify();

            ConfigureAuth(app);

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();

            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }

    internal class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;

            var isAuthorized = filterPipeline
                .Select(filterInfo => filterInfo.Filter)
                .Any(filter => filter is AuthorizeFilter);

            var allowAnonymous = filterPipeline
                .Select(filterInfo => filterInfo.Filter)
                .Any(filter => filter is IAllowAnonymousFilter);

            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "Access Token",
                    Required = true,
                    Type = "string"
                });
            }
        }
    }
}
