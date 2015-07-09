using System;
using System.Web.Mvc;

namespace Aritter.Manager.Web.Controllers
{
	[AllowAnonymous]
	public class ErrorController : DefaultController
	{
		#region Methods

		public ViewResult Index(Exception exceptionHandle)
		{
			return View();
		}

		public ViewResult NotFound()
		{
			return View();
		}

		#endregion Methods
	}
}