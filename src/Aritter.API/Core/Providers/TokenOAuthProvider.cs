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

                var userAccountDto = new UserAccountDto
                {
                    Username = newIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value
                };

                var authorization = authenticationAppService.GetUserAuthorization(userAccountDto);

                if (authorization == null)
                {
                    return;
                }

                var identity = GenerateUserIdentity(authorization, OAuthDefaults.AuthenticationType);
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
                    var authenticationUserDto = new AuthenticationUserDto
                    {
                        Username = context.UserName,
                        Password = context.Password
                    };

                    var authentication = authenticationAppService.AuthenticateUser(authenticationUserDto);

                    if (!authentication.IsAuthenticated)
                    {
                        ThrowHelper.ThrowApplicationException(authentication.Errors);
                    }

                    var authorization = authenticationAppService.GetUserAuthorization(authentication.User);

                    var identity = GenerateUserIdentity(authorization, OAuthDefaults.AuthenticationType);
                    var properties = GenerateUserProperties(authorization);

                    var ticket = new AuthenticationTicket(identity, properties);

                    context.Validated(ticket);
                }
                catch (Infra.Crosscutting.Exceptions.ApplicationException ex)
                {
                    context.SetError(ex.Errors.FirstOrDefault() ?? ex.Message);
                }
                catch (Exception)
                {
                    context.SetError("A unespected error occurs. Please try again later.");
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

        private static AuthenticationProperties GenerateUserProperties(AuthorizationDto authorization)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>());

            return properties;
        }

        private static ClaimsIdentity GenerateUserIdentity(AuthorizationDto authorization, string authenticationType)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, authorization.User.Username),
                new Claim(ClaimTypes.NameIdentifier, authorization.User.UID.ToString()),
                new Claim(ClaimTypes.GivenName, authorization.User.Name ?? authorization.User.Username)
            };

            claims.AddRange(GetRoleClaims(authorization.Roles));
            claims.AddRange(GetPermissionClaims(authorization.Permissions));

            var identity = new ClaimsIdentity(claims, authenticationType);

            return identity;
        }

        private static ICollection<Claim> GetRoleClaims(ICollection<string> roles)
        {
            return roles.Select(p => new Claim(Claims.Role, p)).ToList();
        }

        private static IEnumerable<Claim> GetPermissionClaims(ICollection<string> permissions)
        {
            return permissions.Select(p => new Claim(Claims.Permission, p)).ToList();
        }
    }
}