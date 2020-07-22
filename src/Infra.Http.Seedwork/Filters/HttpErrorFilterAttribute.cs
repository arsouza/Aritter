using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Ritter.Infra.Crosscutting.Exceptions;

namespace Ritter.Infra.Http.Filters
{
    public partial class HttpErrorFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BusinessException)
            {
                context.Result = new BadRequestObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
                return;
            }

            if (context.Exception is NotFoundException)
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
                context.ExceptionHandled = true;
                return;
            }

            context.Result = new InternalServerErrorObjectResult("Ocorreu um erro inesperado. Por favor entre em contato com o admistrador do sistema.");
            context.ExceptionHandled = true;

            base.OnException(context);
        }
    }
}
