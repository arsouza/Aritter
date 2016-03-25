using Aritter.Application.DTO.Security;
using Aritter.Application.Seedwork.Services.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
	[RoutePrefix("values")]
	public class ValuesController : DefaultApiController
	{
		private readonly IUserAppService userService;

		public ValuesController(IUserAppService userService)
		{
			this.userService = userService;
		}

		[AllowAnonymous]
		public async Task<IHttpActionResult> Get()
		{
			return Ok(await Task.FromResult(new UserDTO { UserName = "Teste" }));
		}
	}
}
