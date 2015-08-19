using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Aritter.API.Controllers
{
	[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
	public class ApiBaseController : ApiController
	{
	}
}
