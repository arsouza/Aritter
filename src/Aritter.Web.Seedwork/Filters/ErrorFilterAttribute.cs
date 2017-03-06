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
			ErrorResponse response;

			if (context.Exception is BusinessRuleException)
			{
				logger?.Info(context.Exception.Message);
				response = new ErrorResponse((context.Exception as BusinessRuleException).Errors.ToArray());
			}
			else
			{
				logger?.Error($"Exception: {context.Exception.ToString()}", context.Exception);
				response = new ErrorResponse("There was an unexpected error and the operation was canceled.");
			}

			context.Result = new OkObjectResult(response);
		}
	}
}
