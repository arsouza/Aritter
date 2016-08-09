using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Web.Messages;
using Microsoft.Extensions.Logging;
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
            logger = Crosscutting.Logging.LoggerFactory.CurrentFactory.CreateLogger(this.GetType().Name);
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
                logger.LogInformation(context.Exception.Message);
                response.Reject((context.Exception as ApplicationException).Errors.ToArray());
            }
            else
            {
                logger.LogError($"Exception: {context.Exception.ToString()}", context.Exception);
                response.Reject("There was an unexpected error and the operation was canceled.");
            }

            return context.Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
