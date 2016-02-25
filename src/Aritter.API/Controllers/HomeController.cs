using System.Web.Mvc;

namespace Aritter.Presentation.WebApi.Controllers
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
