using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Logging;
using Aritter.API.Seedwork.Messages;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Aritter.API.Seedwork.Filters
{
    public sealed class ErrorFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger logger;

        public ErrorFilterAttribute()
        {
            logger = LoggerFactory.CreateLogger();
        }

        public override void OnException(ExceptionContext context)
        {
            var response = new ErrorResponse();

            if (context.Exception is ApplicationException)
            {
                logger?.Info(context.Exception.Message);
                response.Reject((context.Exception as ApplicationException).Errors.ToArray());
            }
            else
            {
                logger?.Error($"Exception: {context.Exception.ToString()}", context.Exception);
                response.Reject("There was an unexpected error and the operation was canceled.");
            }

            context.Result = new OkObjectResult(response);
        }
    }
}
