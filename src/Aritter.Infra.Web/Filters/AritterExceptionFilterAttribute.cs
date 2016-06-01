using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Logging;
using Aritter.Infra.Web.Messages;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Aritter.Infra.Web.Filters
{
	public sealed class AritterExceptionFilterAttribute : ExceptionFilterAttribute
	{
		private readonly ILogger logger;

		public AritterExceptionFilterAttribute()
			: base()
		{
			logger = LoggerFactory.CreateLog();
		}

		public override void OnException(HttpActionExecutedContext context)
		{
			context.Response = CreateErrorResponse(context);
		}

		private HttpResponseMessage CreateErrorResponse(HttpActionExecutedContext context)
		{
			var response = new ErrorResponse();

			if (context.Exception is ApplicationErrorException)
			{
				logger.Debug(null, context.Exception);
				response.Reject((context.Exception as ApplicationErrorException).ApplicationErrors.ToArray());
			}
			else
			{
				logger.Debug("There was an unexpected error and the operation was canceled.", context.Exception);
				response.Reject("There was an unexpected error and the operation was canceled.");
			}

			return context.Request.CreateResponse(HttpStatusCode.OK, response);
		}
	}
}
