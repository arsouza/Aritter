using Aritter.Application.DTO.SecurityModule.Users;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Infra.Crosscutting.Security;
using Aritter.Infra.Web.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : DefaultApiController
    {
        private IUserAppService userAppService;

        public UsersController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpGet]
        [Route("users/{username}")]
        [Authorization("Users", Rule.Read)]
        public async Task<IHttpActionResult> GetUserAccount(string username)
        {
            return await Task.Run(() => Success(new UserAccountDto()));
        }

        [HttpGet]
        [Route("users/{username}/profile")]
        [Authorization("Users", Rule.Read)]
        public async Task<IHttpActionResult> GetUserProfile(string username)
        {
            return await Task.Run(() => Success((UserAccountDto)null));
        }

        [HttpPost]
        [Route("users")]
        //[Authorization("Users", Rule.Write)]
        public async Task<IHttpActionResult> AddUserAccount([FromBody]AddUserAccountDto user)
        {
            return await Task.Run(() => Success(userAppService.AddUserAccount(user)));
        }
    }
}