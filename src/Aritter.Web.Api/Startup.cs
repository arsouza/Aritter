using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Aritter.Web.Api.Startup))]

namespace Aritter.Web.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
