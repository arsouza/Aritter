using System.Web.Optimization;

namespace Aritter.Manager.Web
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/styles/main").Include(
				"~/Content/libs/bootstrap/dist/css/bootstrap.min.css",
				"~/Content/libs/font-awesome/css/font-awesome.min.css",
				"~/Content/css/manager.min.css",
				"~/Content/libs/iCheck/skins/square/blue.css"));

			bundles.Add(new ScriptBundle("~/scripts/ie-hack").Include(
				"~/Content/libs/html5shiv/dist/html5shiv.js",
				"~/Content/libs/respond/dest/respond.min.js"));

			bundles.Add(new ScriptBundle("~/scripts/main").Include(
				"~/Content/libs/jquery/dist/jquery.min.js",
				"~/Content/libs/bootstrap/dist/js/bootstrap.min.js",
				"~/Content/libs/iCheck/icheck.min.js"));
		}
	}
}
