using System;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Http.Configurations;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDefaultServices(this IApplicationBuilder app)
        {
            return app.UseDefaultServices(options =>
            {
                options.SwaggerEndpointName = "Swagger UI v1";
            });
        }

        public static IApplicationBuilder UseDefaultServices(this IApplicationBuilder app, Action<ApplicationBuilderOptions> setupAction)
        {
            var optionsBuilder = new ApplicationBuilderOptions();
            setupAction?.Invoke(optionsBuilder);

            app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(ApplicationConstants.SwaggerEndpoint, optionsBuilder.SwaggerEndpointName);
                    c.DisplayRequestDuration();
                    c.RoutePrefix = string.Empty;
                })
                .UseCors()
                .UseMvc();

            return app;
        }
    }
}
