using System.Web.Mvc;

namespace Aritter.Web.Controllers
{
	public class HomeController : DefaultController
	{
		#region Methods

		public ActionResult Index()
		{
			userManager.GetUser(1);
			return View();
		}

		#endregion Methods
	}
}