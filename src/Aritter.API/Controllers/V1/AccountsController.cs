using Aritter.Application.DTO.SecurityModule;
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
        public async Task<IHttpActionResult> GetCurrentAccount()
        {
            return await GetAccount(new GetUserAccountDto { Username = Authentication.User.Identity.Name });
        }

        [HttpGet]
        [Route("accounts/{username}")]
        [Authorization("Aritter", "Accounts", Rule.Read)]
        public async Task<IHttpActionResult> GetAccount([FromUri] GetUserAccountDto account)
        {
            return await Task.Run(() => Success(userAppService.GetAccount(account)));
        }

        [HttpGet]
        [Route("accounts/{username}/profile")]
        [Authorization("Aritter", "PublicProfiles", Rule.Read)]
        public async Task<IHttpActionResult> GetUserProfile(string username)
        {
            return await Task.Run(() => Success((UserAccountDto)null));
        }

        [HttpPost]
        [Route("accounts")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> AddAccount([FromBody]AddUserAccountDto user)
        {
            return await Task.Run(() => Success(userAppService.AddAccount(user)));
        }

        [HttpGet]
        [Route("accounts/{username}/permissions")]
        [Authorization("Aritter", "Security", Rule.Read)]
        public async Task<IHttpActionResult> GetAccountPermissions(string username)
        {
            var account = new UserAccountDto { Username = username };
            return await Task.Run(() => Success(authenticationAppService.ListAccountPermissions(account)));
        }
    }
}