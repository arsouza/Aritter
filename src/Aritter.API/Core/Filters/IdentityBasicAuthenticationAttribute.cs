using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Aritter.API.Core.Filters
{
	public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
	{
		protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
		{
			UserManager<IdentityUser> userManager = CreateUserManager();

			cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, UserManager doesn't support CancellationTokens.
			IdentityUser user = await userManager.FindAsync(userName, password);

			if (user == null)
			{
				// No user with userName/password exists.
				return null;
			}

			// Create a ClaimsIdentity with all the claims for this user.
			cancellationToken.ThrowIfCancellationRequested(); // Unfortunately, IClaimsIdenityFactory doesn't support CancellationTokens.

			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimTypes.Name, "Brock"));
			claims.Add(new Claim(ClaimTypes.Email, "brockallen@gmail.com"));
			var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

			ClaimsIdentity identity = await userManager.ClaimsIdentityFactory.CreateAsync(userManager, user, "Basic");
			return new ClaimsPrincipal(identity);
		}

		private static UserManager<IdentityUser> CreateUserManager()
		{
			throw new NotImplementedException();
			//return new UserManager<IdentityUser>(new UserStore<IdentityUser>(new UsersDbContext()));
		}
	}
}
