using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Web.Messages;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Aritter.Infra.Web.Filters
{
	public sealed class AritterExceptionFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(HttpActionExecutedContext context)
		{
			LogException(context.Exception);
			context.Response = CreateErrorResponse(context);
		}

		private HttpResponseMessage CreateErrorResponse(HttpActionExecutedContext context)
		{
			var response = new ErrorResponse();

			if (context.Exception is ApplicationErrorException)
			{
				response.Reject((context.Exception as ApplicationErrorException).ApplicationErrors.ToArray());
			}
			else
			{
				response.Reject("There was an unexpected error and the operation was canceled.");
			}

			return context.Request.CreateResponse(HttpStatusCode.OK, response);
		}

		private void LogException(Exception ex)
		{
			ILogger logger = Crosscutting.Logging.LoggerFactory.CurrentFactory.CreateLogger(this.GetType().Name);

			logger.LogError($"===== Begin Service Exception =====");
			logger.LogError($"TransactionAbortedException Message: {ex.Message}", ex);

			Exception current = ex;

			while (current != null)
			{
				logger.LogError($"TransactionAbortedException Message: {current.Message}", current);
				current = current.InnerException;
			}

			logger.LogError($"===== End Service Exception =====");
		}
	}
}
