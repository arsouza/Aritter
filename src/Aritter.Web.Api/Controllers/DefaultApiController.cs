using Aritter.Web.Api.Core.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Aritter.Web.Api.Controllers
{
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer), AritterExceptionFilter]
    public abstract class DefaultApiController : ApiController
    {
        protected IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }
    }
}
