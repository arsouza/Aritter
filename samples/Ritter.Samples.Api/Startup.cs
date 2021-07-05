using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ritter.Infra.Crosscutting.Localization;
using Ritter.Infra.Crosscutting.Validations;
using Ritter.Infra.Http.Filters;
using Ritter.Samples.Api.Extensions;
using Ritter.Samples.Api.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ritter.Samples.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices(Configuration);
            services.AddValidatorFactory<EntityRulesValidatorFactory>();
            services.AddAutoMapperTypeAdapter();

            services
                 .AddControllers(options =>
                 {
                     options.Filters.Add(new HttpErrorFilterAttribute());
                     options.EnableEndpointRouting = false;
                 })
                 .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                     options.SerializerSettings.Formatting = Formatting.Indented;
                 });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API V1");
                    c.DisplayRequestDuration();
                    c.RoutePrefix = string.Empty;
                });

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ApplicationCultures.Portugues, ApplicationCultures.Portugues),
                SupportedCultures = new List<CultureInfo>
                {
                    ApplicationCultures.Portugues,
                },
                SupportedUICultures = new List<CultureInfo>
                {
                    ApplicationCultures.Portugues,
                }
            });

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
