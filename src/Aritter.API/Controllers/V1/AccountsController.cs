using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Web.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : DefaultApiController
    {
        private IUserAppService userAppService;
        private IAuthenticationAppService authenticationAppService;

        public UsersController(IUserAppService userAppService,
                                  IAuthenticationAppService authenticationAppService)
        {
            Check.IsNotNull(userAppService, nameof(userAppService));
            Check.IsNotNull(authenticationAppService, nameof(authenticationAppService));

            this.userAppService = userAppService;
            this.authenticationAppService = authenticationAppService;
        }

        [HttpGet]
        [Route("user")]
        [Authorization]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
            return await GetUser(new GetUserDto { Username = Authentication.User.Identity.Name });
        }

        [HttpGet]
        [Route("users/{username}")]
        [Authorization("Aritter", "Users", Rule.Read)]
        public async Task<IHttpActionResult> GetUser([FromUri] GetUserDto user)
        {
            return await Task.Run(() => Success(userAppService.GetUser(user)));
        }

        [HttpGet]
        [Route("users/{username}/profile")]
        [Authorization("Aritter", "PublicProfiles", Rule.Read)]
        public async Task<IHttpActionResult> GetUserProfile(string username)
        {
            return await Task.Run(() => Success((UserDto)null));
        }

        [HttpPost]
        [Route("users")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> AddUser([FromBody]AddUserDto user)
        {
            return await Task.Run(() => Success(userAppService.AddUser(user)));
        }

        [HttpGet]
        [Route("users/{username}/permissions")]
        [Authorization("Aritter", "Security", Rule.Read)]
        public async Task<IHttpActionResult> GetUserPermissions(string username)
        {
            var user = new UserDto { Username = username };
            return await Task.Run(() => Success(authenticationAppService.ListUserPermissions(user)));
        }
    }
}