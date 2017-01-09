using Aritter.API.Seedwork.Filters;
using Aritter.API.Seedwork.Security.Providers;
using Aritter.Security.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using System.IO;

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
            services.AddOptions();

            services.ConfigureDependencies(Configuration);

            // Configure JwtIssuerOptions
            services.Configure<JwtBearerTokenOptions>(options =>
            {
                options.Issuer = Configuration["JwtBearerTokenOptions:Issuer"];
                options.Audience = Configuration["JwtBearerTokenOptions:Audience"];
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Aritter.Security.API.xml"));
                options.OperationFilter<SwaggerAuthorizationHeaderParameterFilter>();
            });

            services.AddMvc(config =>
            {
                config.Filters.Add(new ErrorFilterAttribute());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            ConfigureAuth(app);

            app.UseSwagger();
            app.UseSwaggerUi();

            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
