using Aritter.Manager.Application.Services;
using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Configuration;
using Aritter.Manager.Infrastructure.Extensions;
using Aritter.Manager.Infrastructure.Injection;
using Aritter.Manager.Web.Core.Aggregates;
using Aritter.Manager.Web.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aritter.Manager.Web.Core.Attributes
{
	public class AuthorizationAttribute : AuthorizeAttribute
	{
		#region Members

		private readonly IUserAppService userAppService;
		private readonly int currentUser;

		#endregion

		#region Constructors

		public AuthorizationAttribute()
		{
			userAppService = DependencyProvider.Instance.GetInstance<IUserAppService>();
			currentUser = ApplicationSettings.CurrentUser.GetId();
		}

		#endregion

		#region Methods

		public override void OnAuthorization(AuthorizationContext filterContext)
		{
			if (!AuthorizeCore(filterContext.HttpContext))
			{
				base.OnAuthorization(filterContext);
				return;
			}

			var route = filterContext.GetRoute();
			CheckAuthorization(filterContext, route);

			if (CheckChangePasswordRequired(route))
			{
				var redirectUrl = new UrlHelper(filterContext.RequestContext).Action("ChangePassword", "Account", new { returnUrl = route.CurrentPath });
				filterContext.Result = new RedirectResult(redirectUrl);
			}
		}

		private bool CheckChangePasswordRequired(RouteData route)
		{
			var changePasswordRequired = userAppService.CheckChangePasswordRequired(currentUser);

			return changePasswordRequired
				&& route.RequestArea == null
				&& route.RequestController == "Account"
				&& route.RequestAction == "ChangePassword";
		}

		private void CheckAuthorization(AuthorizationContext filterContext, RouteData route)
		{
			if (route.RequestActionAllowAnonymous)
				return;

			var actionRules = GetActionRules(filterContext);

			if (!actionRules.Any())
				return;

			if (!HasAuthorization(route.RequestArea, route.RequestAction, route.RequestController, actionRules))
				throw new HttpException((int)HttpStatusCode.NotFound, "Not found");
		}

		private bool HasAuthorization(string area, string action, string controller, IEnumerable<Rule> actionRules)
		{
			if (string.IsNullOrEmpty(action) && string.IsNullOrEmpty(controller))
				return true;

			var userRules = userAppService
				.GetRules(currentUser, area, controller, action);

			return userRules.Contains(Rule.All) || userRules.Intersect(actionRules).Any();
		}

		private ICollection<Rule> GetActionRules(AuthorizationContext filterContext)
		{
			var requiredRules = filterContext.ActionDescriptor.GetCustomAttributes(typeof(RequiredRuleAttribute), false).Cast<RequiredRuleAttribute>();

			return requiredRules
				.SelectMany(p => p.Rules)
				.Distinct()
				.ToList();
		}

		#endregion
	}
}