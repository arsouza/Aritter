using Aritter.Presentation.WebApi.Core.Filters;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Aritter.Presentation.WebApi.Controllers
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
