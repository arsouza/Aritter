using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Logging;
using Aritter.Web.Seedwork.Messages;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Aritter.Web.Seedwork.Filters
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
			BusinessRuleException exception = context.Exception as BusinessRuleException;

			if (exception != null)
			{
				logger?.Debug(context.Exception.ToString());
				context.Result = new OkObjectResult(new ErrorResponse(exception.Errors.ToArray()));
				return;
			}

			logger?.Debug($"Exception: {context.Exception.ToString()}");
			context.Result = new OkObjectResult(new ErrorResponse("There was an unexpected error and the operation was canceled."));
		}
	}
}
