using Aritter.API.Attributes;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;

namespace Aritter.API.Controllers
{
	[ControllerFilter]
	public class BaseController : ApiController
	{
		protected override FormattedContentResult<T> Content<T>(HttpStatusCode statusCode, T value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType)
		{
			return base.Content<T>(statusCode, value, formatter, mediaType);
		}

		protected override NegotiatedContentResult<T> Content<T>(HttpStatusCode statusCode, T value)
		{
			return base.Content<T>(statusCode, value);
		}
	}
}
