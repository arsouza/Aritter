using Aritter.Application.Managers;
using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Configuration;
using Aritter.Infrastructure.Extensions;
using Aritter.Infrastructure.Injection;
using Aritter.Web.Core.Aggregates;
using Aritter.Web.Core.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aritter.Web.Core.Attributes
{
	public class AuthorizationAttribute : AuthorizeAttribute
	{
		#region Members

		private readonly IUserManager userManager;
		private readonly int currentUser;

		#endregion

		#region Constructors

		public AuthorizationAttribute()
		{
			userManager = DependencyProvider.Instance.GetInstance<IUserManager>();
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

		public override bool IsDefaultAttribute()
		{
			return base.IsDefaultAttribute();
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			return base.AuthorizeCore(httpContext);
		}

		private bool CheckChangePasswordRequired(RouteData route)
		{
			var changePasswordRequired = userManager.CheckChangePasswordRequired(currentUser);

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

			var userRules = userManager
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