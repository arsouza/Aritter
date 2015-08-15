using Aritter.Application.Managers;
using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Configuration;
using Aritter.Infrastructure.Extensions;
using Aritter.Infrastructure.Injection;
using Aritter.Infrastructure.Injection.Providers;
using Aritter.Infrastructure.Logging;
using Aritter.Web.Core.Aggregates;
using Aritter.Web.Core.Attributes;
using Aritter.Web.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Web.Mvc;

namespace Aritter.Web.Controllers
{
	[HandleError, Authorization]
	public abstract class DefaultController : Controller
	{
		#region Fields

		protected readonly IUserManager userManager;

		#endregion Fields

		#region Constructors

		public DefaultController()
		{
			userManager = ServiceProvider.Get<IUserManager>();
		}

		#endregion Constructors

		#region Methods

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			SetUserPermissions(filterContext);
		}

		protected override void OnException(ExceptionContext filterContext)
		{
			Logger.Application.Error(filterContext.Exception.Message);
			Logger.Application.Error(filterContext.Exception);
			base.OnException(filterContext);
		}

		protected ActionResult RedirectToHome()
		{
			return RedirectToAction("Index", "Home");
		}

		protected ActionResult RedirectToUrl(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);
			return RedirectToHome();
		}

		protected ViewModelPermission GetActionPermissions(string area, string controller, string action, bool allowAnonymous)
		{
			if (allowAnonymous)
				return new ViewModelPermission { Read = true, Write = true, Delete = true, Execute = true };

			if (!ApplicationSettings.CurrentUser.IsAuthenticated)
				return new ViewModelPermission { Read = false, Write = false, Delete = false, Execute = false };

			var rules = userManager.GetRules(ApplicationSettings.CurrentUser.GetId(), area, controller, action);

			return new ViewModelPermission
			{
				Read = rules.Any(p => p == Rule.All || p == Rule.Read),
				Write = rules.Any(p => p == Rule.All || p == Rule.Write),
				Delete = rules.Any(p => p == Rule.All || p == Rule.Delete),
				Execute = rules.Any(p => p == Rule.All || p == Rule.Execute)
			};
		}

		protected string ToJson(object value)
		{
			var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
			return JsonConvert.SerializeObject(value, settings);
		}

		private void SetUserPermissions(ActionExecutingContext filterContext)
		{
			var route = filterContext.GetRoute();
			ViewBag.Permissions = GetActionPermissions(route.RequestArea, route.RequestController, route.RequestAction, route.RequestActionAllowAnonymous);
		}

		#endregion Methods
	}
}