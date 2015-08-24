using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Aritter.WebApi.Startup))]

namespace Aritter.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
