using Aritter.API.Core.Attributes;
using Aritter.Application.Seedwork.Services.Security;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [RoutePrefix("api/account")]
    [Authorization]
    public class AccountController : DefaultApiController
    {
        private readonly IUserAppService userAppService;

        public AccountController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        // POST api/Account/Logout
        [Route("signout")]
        [HttpPost]
        public async Task<IHttpActionResult> SignOut()
        {
            return await Task.Run(() =>
            {
                Authentication.SignOut(OAuthDefaults.AuthenticationType);
                return Ok();
            });
        }

        [Route("info")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUserInfo()
        {
            return await Task.Run(() =>
            {
                var user = userAppService.GetAuthorizations(User.Identity.Name);

                return Ok(user);
            });
        }
    }
}
