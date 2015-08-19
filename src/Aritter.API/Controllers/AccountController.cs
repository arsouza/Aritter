using Aritter.API.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
	[Authorize]
	[RoutePrefix("api/Account")]
	public class AccountController : ApiBaseController
	{
		private const string LocalLoginProvider = "Local";

		public AccountController()
		{
		}

		// POST api/Account/Logout
		[Route("Logout")]
		public IHttpActionResult Logout()
		{
			Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
			return Ok();
		}

		// POST api/Account/Register
		[AllowAnonymous]
		[Route("Register")]
		public async Task<IHttpActionResult> Register(RegisterBindingModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			//var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

			//IdentityResult result = await UserManager.CreateAsync(user, model.Password);

			//if (!result.Succeeded)
			//{
			//	return GetErrorResult(result);
			//}

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
						ModelState.AddModelError("", error);
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
