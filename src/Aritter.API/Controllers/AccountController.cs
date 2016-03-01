using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : DefaultApiController
    {
        // POST api/Account/Logout
        [Route("SignOut"), HttpPost]
        public IHttpActionResult SignOut()
        {
            Authentication.SignOut(OAuthDefaults.AuthenticationType);
            return Ok();
        }
    }
}
