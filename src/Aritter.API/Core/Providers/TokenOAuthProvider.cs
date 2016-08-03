using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.IoC.Providers;
using Aritter.Infra.Web.Security;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.API.Core.Providers
{
    public class TokenOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            await Task.Run(() =>
            {
                var authenticationAppService = InstanceProvider.Get<IAuthenticationAppService>();
                var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
                var username = newIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                var authentication = authenticationAppService.GetAuthorization(username);

                if (authentication == null)
                {
                    return;
                }

                var identity = GenerateUserIdentity(authentication, OAuthDefaults.AuthenticationType);
                var newTicket = new AuthenticationTicket(identity, context.Ticket.Properties);

                context.Validated(newTicket);
            });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Run(() =>
            {
                try
                {
                    var authenticationAppService = InstanceProvider.Get<IAuthenticationAppService>();
                    var authentication = authenticationAppService.Authenticate(context.UserName, context.Password);

                    var identity = GenerateUserIdentity(authentication, OAuthDefaults.AuthenticationType);
                    var properties = GenerateUserProperties(authentication);

                    var ticket = new AuthenticationTicket(identity, properties);

                    context.Validated(ticket);
                }
                catch (ApplicationErrorException ex)
                {
                    context.SetError(ex.Message);
                }
                catch (Exception ex)
                {
                    context.SetError(ex.Message);
                }
            });
        }

        public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
        {
            return base.TokenEndpointResponse(context);
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

        private static AuthenticationProperties GenerateUserProperties(AuthenticationDto authentication)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>());

            return properties;
        }

        private static ClaimsIdentity GenerateUserIdentity(AuthenticationDto authentication, string authenticationType)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, authentication.User.Username),
                new Claim(ClaimTypes.NameIdentifier, authentication.User.UID.ToString()),
                new Claim(ClaimTypes.GivenName, authentication.User.FirstName)
            };

            claims.AddRange(GetRoleClaims(authentication.Roles));
            claims.AddRange(GetPermissionClaims(authentication.Permissions));

            var identity = new ClaimsIdentity(claims, authenticationType);

            return identity;
        }

        private static IEnumerable<Claim> GetRoleClaims(ICollection<string> roles)
        {
            foreach (var claim in roles)
            {
                yield return new Claim(Claims.Role, claim);
            }
        }

        private static IEnumerable<Claim> GetPermissionClaims(ICollection<string> permissions)
        {
            foreach (var claim in permissions)
            {
                yield return new Claim(Claims.Permission, claim);
            }
        }
    }
}