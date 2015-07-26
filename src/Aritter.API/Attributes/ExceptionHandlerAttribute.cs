using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Aritter.API.Attributes
{
	public class ExceptionHandlerAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext actionExecutedContext)
		{
			actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Ooops. Desculpe, alguma coisa não está funcionando como deveria. Estamos trabalhando nisso." });
			base.OnException(actionExecutedContext);
		}
	}
}
