using Aritter.API.Core.Claims;
using Aritter.API.Core.Filters;
using Aritter.Application.DTO.Security;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Infra.IoC.Providers;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.API.Core.Providers
{
	[AritterExceptionFilter]
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
	{
		public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
		{
			await Task.Run(() =>
			{
				using (InstanceProvider.Instance.Container.BeginExecutionContextScope())
				{
					IUserAppService userAppService = InstanceProvider.Get<IUserAppService>();

					var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

					var user = userAppService.GetAuthorizations(newIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

					if (user == null)
					{
						return;
					}

					var identity = GenerateUserIdentity(user, OAuthDefaults.AuthenticationType);
					var newTicket = new AuthenticationTicket(identity, context.Ticket.Properties);

					context.Validated(newTicket);
				}
			});
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			await Task.Run(() =>
			{
				using (InstanceProvider.Instance.Container.BeginExecutionContextScope())
				{
					IUserAppService userAppService = InstanceProvider.Get<IUserAppService>();

					var user = userAppService.Authenticate(context.UserName, context.Password);

					if (user == null)
					{
						context.SetError("invalid_grant", "The user name or password is incorrect.");
						return;
					}

					var identity = GenerateUserIdentity(user, OAuthDefaults.AuthenticationType);

					context.Validated(identity);
				}
			});
		}

		public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			await Task.Run(() =>
			{
				context.AdditionalResponseParameters.Add("expires", context.Properties.ExpiresUtc.GetValueOrDefault().LocalDateTime);
			});
		}

		public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			await Task.Run(() =>
			{
				context.Validated();
			});
		}

		public ClaimsIdentity GenerateUserIdentity(UserDTO user, string authenticationType)
		{
			var claims = new List<Claim>();

			claims.Add(new Claim(ClaimTypes.Name, user.UserName));
			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Guid.ToString()));
			claims.AddRange(GetModuleClaims(user));
			claims.AddRange(GetRoleClaims(user));
			claims.AddRange(GetPermissionClaims(user));

			var identity = new ClaimsIdentity(claims, authenticationType);

			return identity;
		}

		private IEnumerable<Claim> GetModuleClaims(UserDTO user)
		{
			var claims = user.Roles.SelectMany(r => r.Role.Authorizations.Select(a => a.Permission.Feature.Module.Name)).Distinct();

			foreach (var claim in claims)
			{
				yield return new Claim(ClaimConstants.Module, claim);
			}
		}

		private IEnumerable<Claim> GetRoleClaims(UserDTO user)
		{
			var claims = user.Roles.Select(r => r.Role.Name).Distinct();

			foreach (var claim in claims)
			{
				yield return new Claim(ClaimConstants.Role, claim);
			}
		}

		private IEnumerable<Claim> GetPermissionClaims(UserDTO user)
		{
			var claims = user.Roles.SelectMany(r => r.Role.Authorizations.Select(a => string.Format("{0}:{1}", a.Permission.Feature.Name, a.Permission.Rule))).Distinct();

			foreach (var claim in claims)
			{
				yield return new Claim(ClaimConstants.Permission, claim);
			}
		}
	}
}