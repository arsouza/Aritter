using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Ritter.Application.Results;
using Ritter.Infra.Crosscutting.Exceptions;

namespace Ritter.Infra.Http.Filters
{
    public class HttpErrorFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.Is<ValidationException>())
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
                return;
            }

            if (context.Exception.Is<NotFoundObjectException>())
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
                return;
            }

            base.OnException(context);
        }
    }

    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;
        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            logger.LogError(
                new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            if (context.Exception is ValidationException validationException)
            {
                context.Result = new BadRequestObjectResult(validationException.Message);
                context.ExceptionHandled = true;
                return;
            }
            else if (context.Exception is NotFoundObjectException foundObjectException)
            {
                context.Result = new NotFoundObjectResult(foundObjectException.Message);
                context.ExceptionHandled = true;
                return;
            }
            else
            {
                var result = new ApiResult(context.Exception);

                result.Errors.Prepend("Ops, estamos passando por instabilidades, tente novamente em alguns minutos");

                context.Result = new InternalServerErrorObjectResult(result);
                context.ExceptionHandled = true;
            }
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }

            public object DeveloperMessage { get; set; }
        }

        public class InternalServerErrorObjectResult : ObjectResult
        {
            public InternalServerErrorObjectResult(object error) : base(error)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
