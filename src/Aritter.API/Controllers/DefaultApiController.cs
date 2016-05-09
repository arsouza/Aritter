using Aritter.Infra.Web.Filters.Exceptions;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    [AritterExceptionFilter]
    [Authorize]
    public abstract class DefaultApiController : ApiController
    {
        protected IAuthenticationManager Authentication => Request.GetOwinContext().Authentication;
    }
}
