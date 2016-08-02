using Aritter.Application.DTO.SecurityModule.Authentication;
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
		[Route("users/{id:int}")]
		[Authorization("Users", Rule.Get)]
		public async Task<IHttpActionResult> GetById(int id)
		{
			return await Task.Run(() => Success(new UserDto()));
		}

		[HttpGet]
		[Route("users/{username}")]
		[Authorization("Users", Rule.Get)]
		public async Task<IHttpActionResult> GetByUsername(string username)
		{
			return await Task.Run(() => Success(new UserDto()));
		}

		[HttpGet]
		[Route("users/{id:int}/profile")]
		[Authorization("Users", Rule.Get)]
		public async Task<IHttpActionResult> GetProfile(int id)
		{
			return await Task.Run(() => Success((UserDto)null));
		}

		[HttpPost]
		[Route("users")]
		[AllowAnonymous]
		public async Task<IHttpActionResult> Post([FromBody]AddUserDto user)
		{
			return await Task.Run(() =>
			{
				return Success(userAppService.CreateUser(user));
			});
		}

		//// PUT api/<controller>/5
		//public void Put(int id, [FromBody]string value)
		//{
		//}

		//// DELETE api/<controller>/5
		//public void Delete(int id)
		//{
		//}
	}
}