using System.Web.Mvc;

namespace Aritter.API.Controllers
{
    public class HomeController : DefaultController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
