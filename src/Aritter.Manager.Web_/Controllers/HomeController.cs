using System.Web.Mvc;

namespace Aritter.Manager.Web.Controllers
{
	public class HomeController : DefaultController
	{
		#region Methods

		public ActionResult Index()
		{
			userAppService.GetUser(1);
			return View();
		}

		#endregion Methods
	}
}