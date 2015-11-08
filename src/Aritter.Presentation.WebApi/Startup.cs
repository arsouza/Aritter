using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Aritter.Presentation.WebApi.Startup))]

namespace Aritter.Presentation.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
