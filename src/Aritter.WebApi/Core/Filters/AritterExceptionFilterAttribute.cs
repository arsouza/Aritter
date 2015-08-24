using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Aritter.WebApi.Core.Filters
{
    internal class AritterExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, "Ooops. Alguma coisa errada aconteceu e nós não esperávamos. Desculpe. Estamos verificando o que aconteceu e em breve estará funcionando.");
            }
        }
    }
}
