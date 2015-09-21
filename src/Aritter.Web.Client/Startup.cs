using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;

namespace Aritter.Web.Client
{
	public class Startup
    {
		public Startup(IHostingEnvironment env)
		{
		}

		// This method gets called by a runtime.
		// Use this method to add services to the container
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
        }
    }
}
