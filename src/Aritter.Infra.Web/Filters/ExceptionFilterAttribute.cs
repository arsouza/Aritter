using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Logging;
using Aritter.Infra.Web.Messages;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Aritter.Infra.Web.Filters
{
    public sealed class ExceptionFilterAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        private readonly ILogger logger;

        public ExceptionFilterAttribute()
        {
            logger = LoggerFactory.CreateLogger();
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = CreateResponse(context);
        }

        private HttpResponseMessage CreateResponse(HttpActionExecutedContext context)
        {
            var response = new ErrorResponse();

            if (context.Exception is ApplicationException)
            {
                logger.Info(context.Exception.Message);
                response.Reject((context.Exception as ApplicationException).Errors.ToArray());
            }
            else
            {
                logger.Error($"Exception: {context.Exception.ToString()}", context.Exception);
                response.Reject("There was an unexpected error and the operation was canceled.");
            }

            return context.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
