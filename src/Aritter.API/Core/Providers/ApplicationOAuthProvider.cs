using Aritter.Application.DTO.Security;
using Aritter.Application.Seedwork.Services.Security;
using Aritter.Infra.IoC.Providers;
using Aritter.Infra.Web.Security;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.API.Core.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            await Task.Run(() =>
            {
                using (InstanceProvider.Instance.Container.BeginExecutionContextScope())
                {
                    var userAppService = InstanceProvider.Get<IUserAppService>();
                    var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

                    var user = userAppService.GetAuthorizations(newIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value);

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
                    var userAppService = InstanceProvider.Get<IUserAppService>();

                    var user = userAppService.Authenticate(context.UserName, context.Password);

                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                        return;
                    }

                    var identity = GenerateUserIdentity(user, OAuthDefaults.AuthenticationType);
                    var properties = GenerateUserProperties(user);

                    var ticket = new AuthenticationTicket(identity, properties);
                    context.Validated(ticket);
                }
            });
        }

        public override async Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            await Task.Run(() =>
            {
                foreach (var property in context.Properties.Dictionary)
                {
                    if (!property.Key.StartsWith("."))
                    {
                        context.AdditionalResponseParameters.Add(property.Key, property.Value);
                    }
                }

                context.AdditionalResponseParameters.Add("expires", context.Properties.ExpiresUtc.GetValueOrDefault().LocalDateTime);
            });
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => { context.Validated(); });
        }

        private static AuthenticationProperties GenerateUserProperties(UserDTO user)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>());

            return properties;
        }

        private static ClaimsIdentity GenerateUserIdentity(UserDTO user, string authenticationType)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Guid.ToString()),
                new Claim(ClaimTypes.GivenName, user.FirstName)
            };

            claims.AddRange(GetModuleClaims(user));
            claims.AddRange(GetRoleClaims(user));
            claims.AddRange(GetPermissionClaims(user));

            var identity = new ClaimsIdentity(claims, authenticationType);

            return identity;
        }

        private static IEnumerable<Claim> GetModuleClaims(UserDTO user)
        {
            var claims = user.Roles.SelectMany(r => r.Authorizations.Select(a => a.Permission.Resource.Module.Name)).Distinct();

            foreach (var claim in claims)
            {
                yield return new Claim(Claims.Module, claim);
            }
        }

        private static IEnumerable<Claim> GetRoleClaims(UserDTO user)
        {
            var claims = user.Roles.Select(r => r.Name).Distinct();

            foreach (var claim in claims)
            {
                yield return new Claim(Claims.Role, claim);
            }
        }

        private static IEnumerable<Claim> GetPermissionClaims(UserDTO user)
        {
            var claims = user.Roles.SelectMany(r => r.Authorizations.Select(a => $"{a.Permission.Resource.Name}:{a.Permission.Rule}")).Distinct();

            foreach (var claim in claims)
            {
                yield return new Claim(Claims.Permission, claim);
            }
        }
    }
}