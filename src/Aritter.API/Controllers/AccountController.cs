using Aritter.Application.Seedwork.Services.Security;
using Aritter.Infra.Web.Security;
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
