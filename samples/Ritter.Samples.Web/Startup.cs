using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ritter.Infra.Crosscutting.Validations;
using Ritter.Infra.Http.Filters;
using Ritter.Samples.Application.Projections;
using Ritter.Samples.Web.Swagger;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration.GetConnectionString("DefaultConnection"));
            services.AddTypeAdapterFactory<AutoMapperTypeAdapterFactory>();
            services.AddValidatorFactory<EntityRulesValidatorFactory>();

            services
                .AddMvc(s => s.Filters.Add(new HttpErrorFilterAttribute()))
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Formatting = Formatting.Indented;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1); ;

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
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ritter Sample API V1");
                c.DisplayRequestDuration();
                c.RoutePrefix = string.Empty;
            });

            app.UseTypeAdapterFactory();
            app.UseValidatorFactory();
            app.UseMvc();
        }

        private static string GetXmlComments()
        {
            string xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }
    }
}
