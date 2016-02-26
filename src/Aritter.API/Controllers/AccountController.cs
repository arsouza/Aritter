using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : DefaultApiController
    {
        public AccountController()
        {
        }

        // POST api/Account/Logout
        [Route("Logout"), HttpPost]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(OAuthDefaults.AuthenticationType);
            return Ok();
        }

        #region Helpers

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion
    }
}
