using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ritter.Infra.Http.Filters;
using Ritter.Samples.Application.TypeAdapters.AutoMapper;
using Ritter.Samples.Web.Configuration;
using Ritter.Samples.Web.SwaggerFilters;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Ritter.Samples.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public AppSettings AppSettings
            => Configuration.Get<AppSettings>();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration.GetConnectionString("DefaultConnection"));
            services.AddTypeAdapterFactory<AutoMapperTypeAdapterFactory>();

            services
                .AddMvc(s =>
                {
                    s.Filters.Add(new HttpErrorFilterAttribute());
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Ritter Sample API", Version = "v1" });
                c.IncludeXmlComments(GetXmlComments());
                c.DocumentFilter<LowercaseDocumentFilter>();
                c.DescribeAllParametersInCamelCase();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(AppSettings.Swagger.Endpoint, "Ritter Sample API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseTypeAdapterFactory();
            app.UseMvc();
        }

        private static string GetXmlComments()
        {
            var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }
    }
}
