using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Aritter.API_.Attributes
{
	public class AuthorizationAttribute : AuthorizeAttribute
	{
		public override void OnAuthorization(HttpActionContext actionContext)
		{
			base.OnAuthorization(actionContext);

			if (!IsAuthorized(actionContext))
			{
				actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Você não tem permissão para completar a requisição." });
				return;
			}
		}
	}
}
