using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Aritter.Infra.Web.Filters.Exceptions
{
    public sealed class AritterExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, "Ooops. Alguma coisa errada aconteceu e nós não esperávamos. Desculpe. Estamos verificando o que aconteceu e em breve estará funcionando.");
        }
    }
}
