using Aritter.Manager.Application.Services;
using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Configuration;
using Aritter.Manager.Infrastructure.Extensions;
using Aritter.Manager.Infrastructure.Injection;
using Aritter.Manager.Infrastructure.Logging;
using Aritter.Manager.Web.Core.Aggregates;
using Aritter.Manager.Web.Core.Attributes;
using Aritter.Manager.Web.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Web.Mvc;

namespace Aritter.Manager.Web.Controllers
{
	[HandleError, Authorization]
	public abstract class DefaultController : Controller
	{
		#region Fields

		protected readonly IUserAppService userAppService;

		#endregion Fields

		#region Constructors

		public DefaultController()
		{
			this.userAppService = DependencyProvider.Instance.GetInstance<IUserAppService>();
		}

		#endregion Constructors

		#region Methods

		protected override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			this.SetUserPermissions(filterContext);
		}

		protected override void OnException(ExceptionContext filterContext)
		{
			Logger.Application.Error(filterContext.Exception.Message);
			Logger.Application.Error(filterContext.Exception);
			base.OnException(filterContext);
		}

		protected ActionResult RedirectToHome()
		{
			return this.RedirectToAction("Index", "Home");
		}

		protected ActionResult RedirectToUrl(string returnUrl)
		{
			if (this.Url.IsLocalUrl(returnUrl))
				return this.Redirect(returnUrl);
			return this.RedirectToHome();
		}

		protected ViewModelPermission GetActionPermissions(string area, string controller, string action, bool allowAnonymous)
		{
			if (allowAnonymous)
				return new ViewModelPermission { Read = true, Write = true, Delete = true, Execute = true };

			if (ApplicationSettings.CurrentUser.IsAuthenticated)
			{
				var rules = this.userAppService.GetRules(ApplicationSettings.CurrentUser.GetId(), area, controller, action);

				return new ViewModelPermission
				{
					Read = rules.Any(p => p == Rule.All || p == Rule.Read),
					Write = rules.Any(p => p == Rule.All || p == Rule.Write),
					Delete = rules.Any(p => p == Rule.All || p == Rule.Delete),
					Execute = rules.Any(p => p == Rule.All || p == Rule.Execute)
				};
			}

			return new ViewModelPermission { Read = false, Write = false, Delete = false, Execute = false };
		}

		protected string ToJson(object value)
		{
			var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
			return JsonConvert.SerializeObject(value, settings);
		}

		private void SetUserPermissions(ActionExecutingContext filterContext)
		{
			var route = filterContext.GetRoute();
			this.ViewBag.Permissions = this.GetActionPermissions(route.RequestArea, route.RequestController, route.RequestAction, route.RequestActionAllowAnonymous);
		}

		#endregion Methods
	}
}