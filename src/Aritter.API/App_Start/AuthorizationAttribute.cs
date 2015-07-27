using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Aritter.API.App_Start
{
	public class AuthorizationAttribute : AuthorizeAttribute
	{
		public override void OnAuthorization(HttpActionContext actionContext)
		{
			actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Cai fora bobalhão.");

			//base.OnAuthorization(actionContext);
		}

		public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
		{
			actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.NotFound, "Cai fora bobalhão.");

			return Task.FromResult<object>(null);//return base.OnAuthorizationAsync(actionContext, cancellationToken);
		}

		protected override bool IsAuthorized(HttpActionContext actionContext)
		{
			return base.IsAuthorized(actionContext);
		}
	}
}
