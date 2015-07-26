using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace Aritter.API.Attributes
{
	public class ControllerFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (!actionContext.ModelState.IsValid)
			{
				var errors = GetModelStateErrors(actionContext.ModelState);

				actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
			}

			base.OnActionExecuting(actionContext);
		}

		private object GetModelStateErrors(ModelStateDictionary modelState)
		{
			var errors = modelState.Values
				.SelectMany(v => v.Errors)
				.Select(e => e.ErrorMessage)
				.ToList();

			return new
			{
				Message = "Parâmetros inválidos.",
				Errors = errors
			};
		}
	}
}
