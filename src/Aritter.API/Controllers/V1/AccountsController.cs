using Aritter.Application.DTO.SecurityModule.Users;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Security;
using Aritter.Infra.Web.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [RoutePrefix("api/v1")]
    public class AccountsController : DefaultApiController
    {
        private IUserAppService userAppService;
        private IAuthenticationAppService authenticationAppService;

        public AccountsController(IUserAppService userAppService,
                                  IAuthenticationAppService authenticationAppService)
        {
            Check.IsNotNull(userAppService, nameof(userAppService));
            Check.IsNotNull(authenticationAppService, nameof(authenticationAppService));

            this.userAppService = userAppService;
            this.authenticationAppService = authenticationAppService;
        }

        [HttpGet]
        [Route("account")]
        [Authorization]
        public async Task<IHttpActionResult> GetUserAccountInfo()
        {
            return await GetUserAccount(User.Identity.Name);
        }

        [HttpGet]
        [Route("accounts/{username}")]
        [Authorization("Aritter", "Users", Rule.Read)]
        public async Task<IHttpActionResult> GetUserAccount(string username)
        {
            var user = new GetUserAccountDto { Username = username };
            return await Task.Run(() => Success(userAppService.GetUserAccount(user)));
        }

        [HttpGet]
        [Route("accounts/{username}/profile")]
        [Authorization("Aritter", "Users", Rule.Read)]
        public async Task<IHttpActionResult> GetUserProfile(string username)
        {
            return await Task.Run(() => Success((UserAccountDto)null));
        }

        [HttpPost]
        [Route("accounts")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> AddUserAccount([FromBody]AddUserAccountDto user)
        {
            return await Task.Run(() => Success(userAppService.AddUserAccount(user)));
        }

        [HttpGet]
        [Route("accounts/{username}/permissions")]
        [Authorization("Aritter", "Security", Rule.Read)]
        public async Task<IHttpActionResult> GetUserPermissions(string username)
        {
            var userAccountDto = new Application.DTO.SecurityModule.Authentication.UserAccountDto { Username = username };
            return await Task.Run(() => Success(authenticationAppService.ListUserPermissions(userAccountDto)));
        }
    }
}