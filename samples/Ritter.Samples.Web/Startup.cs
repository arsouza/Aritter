using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddDependencies(Configuration);
            services.AddDefaultServices(options =>
            {
                options.SwaggerTitle = "Ritter Sample Api";
                options.SwaggerVersion = "v1";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultServices(options =>
            {
                options.SwaggerEndpointName = "Ritter Sample Api v1";
            });
        }
    }
}
