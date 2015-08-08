using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Aritter.API.Attributes
{
	public class AuthorizationAttribute : AuthorizeAttribute
	{
		private bool isAuthorized = false;

		public override void OnAuthorization(HttpActionContext actionContext)
		{
			base.OnAuthorization(actionContext);

			if (!isAuthorized)
			{
				actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, "Recurso não encontrado.");
			}
		}

		protected override bool IsAuthorized(HttpActionContext actionContext)
		{
			isAuthorized = base.IsAuthorized(actionContext);

			return isAuthorized;
		}
	}
}
