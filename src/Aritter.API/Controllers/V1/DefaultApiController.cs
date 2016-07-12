using Aritter.Infra.Web.Messages;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
    [Authorize]
    public abstract class DefaultApiController : ApiController
    {
        protected IAuthenticationManager Authentication => Request.GetOwinContext().Authentication;

        protected IHttpActionResult Success<TData>(TData data)
            where TData : class
        {
            return Ok(new SuccessResponse<TData>(data));
        }

        protected async Task<IHttpActionResult> SuccessAsync<TData>(TData data)
            where TData : class
        {
            return await Task.Run(() => Success(data));
        }

        protected IHttpActionResult Success<TData>(TData data, params string[] messages)
           where TData : class
        {
            return Ok(new SuccessResponse<TData>(data, messages));
        }

        protected async Task<IHttpActionResult> SuccessAsync<TData>(TData data, params string[] messages)
           where TData : class
        {
            return await Task.Run(() => Success(data, messages));
        }
    }
}
