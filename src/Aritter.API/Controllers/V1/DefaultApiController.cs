using Aritter.Infra.Web.Messages;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    [Authorize]
    public abstract class DefaultApiController : ApiController
    {
        protected IAuthenticationManager Authentication => Request.GetOwinContext().Authentication;

        protected IHttpActionResult Success<TData>(TData data) where TData : class => Ok(new SuccessResponse<TData>(data));

        protected IHttpActionResult Success<TData>(TData data, params string[] messages) where TData : class => Ok(new SuccessResponse<TData>(data, messages));
    }
}
