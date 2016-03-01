using Aritter.API.Core.Filters;
using Aritter.Application.DTO.Security;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Infra.IoC.Providers;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.API.Core.Providers
{
    [AritterExceptionFilter]
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUserAppService userAppService;

        public ApplicationOAuthProvider()
        {
            userAppService = ServiceProvider.Get<IUserAppService>();
        }

        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            // chance to change authentication ticket for refresh token requests
            var newId = new ClaimsIdentity(context.Ticket.Identity);
            newId.AddClaim(new Claim("newClaim", "refreshToken"));

            var user = await userAppService.GetAuthorizationsAsync(newId.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value);

            if (user == null)
            {
                return;
            }

            var identity = await GenerateUserIdentityAsync(user, OAuthDefaults.AuthenticationType);
            var newTicket = new AuthenticationTicket(identity, context.Ticket.Properties);

            await Task.FromResult(context.Validated(newTicket));
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                var user = await userAppService.AuthenticateAsync(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                var identity = await GenerateUserIdentityAsync(user, OAuthDefaults.AuthenticationType);

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("application_error", ex.ToString());
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            context.AdditionalResponseParameters.Add("issued", context.Properties.IssuedUtc.GetValueOrDefault().LocalDateTime);
            context.AdditionalResponseParameters.Add("expires", context.Properties.ExpiresUtc.GetValueOrDefault().LocalDateTime);

            return Task.FromResult<object>(null);
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.FromResult(context.Validated());
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserDTO user, string authenticationType)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Guid.ToString())
            };

            claims.AddRange(GetModuleClaims(user));
            claims.AddRange(GetRoleClaims(user));
            claims.AddRange(GetPermissionClaims(user));

            var identity = new ClaimsIdentity(claims, authenticationType);

            return await Task.FromResult(identity);
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