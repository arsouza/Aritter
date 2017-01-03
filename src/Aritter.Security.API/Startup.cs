using Aritter.API.Seedwork.Filters;
using Aritter.API.Seedwork.Security.Filters;
using Aritter.Infra.Cosscutting.Configuration;
using Aritter.Infra.Data.Seedwork;
using Aritter.Infra.IoC.Containers;
using Aritter.Security.Application.Services.Users;
using Aritter.Security.Domain.Security.Users.Services;
using Aritter.Security.Domain.Users.Aggregates;
using Aritter.Security.Infra.Data;
using Aritter.Security.Infra.Data.Repositories;
using Aritter.Security.Infra.Ioc.Containers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
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
    internal partial class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AritterContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IQueryableUnitOfWork, AritterContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserAppService, UserAppService>();

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Aritter.Security.API.xml"));
                options.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            services.AddMvc(config =>
            {
                config.Filters.Add(new ErrorFilterAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            ConfigureAuth(app);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseSwagger();
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
