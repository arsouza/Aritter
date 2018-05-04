using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ritter.Infra.Crosscutting.Exceptions;
using System;

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
}
