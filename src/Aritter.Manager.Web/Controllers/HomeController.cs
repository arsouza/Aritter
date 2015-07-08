using System.Web.Mvc;

namespace Aritter.Manager.Web.Controllers
{
	public class HomeController : DefaultController
	{
		#region Methods

		public ActionResult Index()
		{
			this.userAppService.GetUser(1);
			return this.View();
		}

		#endregion Methods
	}
}