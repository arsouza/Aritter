using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Aritter.API.Controllers
{
	[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
	public abstract class ApiBaseController : ApiController
	{
		protected IAuthenticationManager Authentication
		{
			get { return Request.GetOwinContext().Authentication; }
		}
	}
}
