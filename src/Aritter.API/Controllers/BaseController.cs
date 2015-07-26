using Aritter.API.Attributes;
using System.Web.Http;

namespace Aritter.API.Controllers
{
	[ActionHandler, ExceptionHandler]
	public class BaseController : ApiController
	{

	}
}
