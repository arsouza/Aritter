using Aritter.Web.Core.Aggregates;
using System.Web.Mvc;

namespace Aritter.Web.Core.Extensions
{
	public static partial class ExtensionManager
	{
		#region Methods

		public static RouteData GetRoute(this ActionExecutingContext filterContext)
		{
			return MakeRoute(filterContext, filterContext.ActionDescriptor);
		}

		public static RouteData GetRoute(this AuthorizationContext filterContext)
		{
			return MakeRoute(filterContext, filterContext.ActionDescriptor);
		}

		private static RouteData MakeRoute(ControllerContext filterContext, ActionDescriptor actionDescriptor)
		{
			var area = GetAreaDescription(filterContext);
			var controller = GetControllerDescription(actionDescriptor.ControllerDescriptor);
			var action = GetActionDescription(actionDescriptor);
			var allowAnonymous = CheckAnnonymous(actionDescriptor);
			var currentPath = filterContext.HttpContext.Request.Url.AbsolutePath;

			return new RouteData
			{
				RequestArea = area,
				RequestController = controller,
				RequestAction = action,
				RequestActionAllowAnonymous = allowAnonymous,
				CurrentPath = currentPath
			};
		}

		private static string GetAreaDescription(ControllerContext filterContext)
		{
			if (filterContext.RouteData.DataTokens["area"] == null)
				return null;

			return (string)filterContext.RouteData.DataTokens["area"];
		}

		private static string GetControllerDescription(ControllerDescriptor controllerDescriptor)
		{
			return controllerDescriptor.ControllerName;
		}

		private static string GetActionDescription(ActionDescriptor actionDescriptor)
		{
			return actionDescriptor.ActionName;
		}

		private static bool CheckAnnonymous(ActionDescriptor actionDescriptor)
		{
			return actionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
				|| (!actionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
					&& actionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true));
		}

		#endregion Methods
	}
}
