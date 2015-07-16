using Aritter.Manager.Api.Migrations;
using Aritter.Manager.Api.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartup(typeof(Aritter.Manager.Api.Startup))]

namespace Aritter.Manager.Api
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
		}
	}
}
