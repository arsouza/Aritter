using System;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Validations;
using Ritter.Infra.Http.Configurations;
using Ritter.Infra.Http.Configurations.Swagger;
using Ritter.Infra.Http.Extensions;
using Ritter.Infra.Http.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddValidatorFactory(this IServiceCollection services, IEntityValidatorFactory validatorFactory)
        {
            Ensure.Argument.NotNull(validatorFactory, nameof(validatorFactory));

            services.AddSingleton(typeof(IEntityValidatorFactory), validatorFactory);
            services.AddSingleton(factory => factory.GetService<IEntityValidatorFactory>().Create());

            return services;
        }

        public static IServiceCollection AddValidatorFactory<TEntityValidatorFactory>(this IServiceCollection services)
            where TEntityValidatorFactory : class, IEntityValidatorFactory, new()
        {
            return services.AddValidatorFactory(new TEntityValidatorFactory());
        }

        public static IServiceCollection AddDefaultServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDefaultServices(configuration, options =>
            {
                options.SwaggerTitle = "Swagger UI";
                options.SwaggerVersion = "v1";
            });
        }

        public static IServiceCollection AddDefaultServices(this IServiceCollection services, IConfiguration configuration, Action<ServicesBuilderOptions> setupAction)
        {
            var optionsBuilder = new ServicesBuilderOptions();
            setupAction?.Invoke(optionsBuilder);

            services.AddValidatorFactory<EntityRulesValidatorFactory>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(configuration.GetCorsOrigins())
                    .AllowCredentials());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(optionsBuilder.SwaggerVersion, new Info
                {
                    Title = optionsBuilder.SwaggerTitle,
                    Version = optionsBuilder.SwaggerVersion
                });
                c.IncludeXmlComments(GetXmlCommentsFile());
                c.DocumentFilter<LowercaseDocumentFilter>();
                c.DescribeAllParametersInCamelCase();
            });

            services
                .AddMvc(s => s.Filters.Add(new HttpErrorFilterAttribute()))
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Formatting = Formatting.Indented;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services;
        }

        private static string GetXmlCommentsFile()
        {
            string xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }
    }
}
