using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Infra.IoC.Providers;
using Aritter.Infra.Web.Security;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.API.Core.Providers
{
    public class OAuthTokenProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            await Task.Run(() =>
            {
                var authenticationAppService = InstanceProvider.Get<IAuthenticationAppService>();
                var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

                var userAccountDto = new UserAccountDto
                {
                    Id = int.Parse(newIdentity.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.Name).Value)
                };

                var permissions = authenticationAppService.ListAccountPermissions(userAccountDto);

                if (permissions == null)
                {
                    return;
                }

                var identity = GenerateUserIdentity(context.Options.AuthenticationType, userAccountDto, permissions);
                var authenticationTicket = new AuthenticationTicket(identity, context.Ticket.Properties);

                context.Validated(authenticationTicket);
            });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Run(() =>
            {
                try
                {
                    var authenticationAppService = InstanceProvider.Get<IAuthenticationAppService>();

                    var userDto = new AuthenticateUserDto
                    {
                        Username = context.UserName,
                        Password = context.Password,
                        ClientId = Guid.Parse(context.ClientId)
                    };

                    var authentication = authenticationAppService.AuthenticateUser(userDto);

                    if (!authentication.IsAuthenticated)
                    {
                        foreach (var error in authentication.Errors)
                        {
                            context.SetError(error);
                        }

                        context.Rejected();
                        return;
                    }

                    var permissions = authenticationAppService.ListAccountPermissions(authentication.User);

                    var identity = GenerateUserIdentity(context.Options.AuthenticationType, authentication.User, permissions);
                    var properties = GenerateUserProperties(context);

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
            await Task.Run(() =>
            {
                string clientId = string.Empty;
                string clientSecret = string.Empty;

                if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
                {
                    context.TryGetFormCredentials(out clientId, out clientSecret);
                }

                if (context.ClientId == null)
                {
                    context.Rejected();
                    context.SetError("invalid_clientId", "ClientId should be sent.");
                    return;
                }

                var clientAppService = InstanceProvider.Get<IClientAppService>();

                var client = clientAppService.GetClientByUID(new GetClientDto { UID = Guid.Parse(context.ClientId) });

                if (client == null)
                {
                    context.Rejected();
                    context.SetError("invalid_clientId", string.Format("Client '{0}' not exists.", context.ClientId));
                    return;
                }

                context.OwinContext.Set("as:clientAllowedOrigin", client.AllowedOrigin ?? "*");
                context.Validated();
            });
        }

        private AuthenticationProperties GenerateUserProperties(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>
            {
                { "as:client_id", context.ClientId ?? string.Empty }
            });

            return properties;
        }

        private ClaimsIdentity GenerateUserIdentity(string authenticationType, UserAccountDto userAccount, ICollection<PermissionDto> permissions)
        {
            var identity = new ClaimsIdentity(authenticationType);

            identity.AddClaim(new Claim(System.Security.Claims.ClaimTypes.Name, userAccount.Username));
            identity.AddClaim(new Claim(System.Security.Claims.ClaimTypes.Role, "user"));
            identity.AddClaim(new Claim(Infra.Web.Security.ClaimTypes.IdentityId, userAccount.Id.ToString(), ClaimValueTypes.Integer));
            identity.AddClaim(new Claim(Infra.Web.Security.ClaimTypes.IdentityUID, userAccount.UID.ToString()));

            var allowedPermissions = GetAllowedPermissions(permissions);

            foreach (var allowedPermission in allowedPermissions.GroupBy(p => new { p.Client, p.Resource }))
            {
                var permission = new Permission(allowedPermission.Key.Client, allowedPermission.Key.Resource);

                foreach (var item in allowedPermission)
                {
                    var rule = Rule.None;
                    if (Enum.TryParse(item.Rule, out rule))
                    {
                        permission.Authorizations.Add(rule);
                    }
                }

                identity.AddClaim(new Claim(Infra.Web.Security.ClaimTypes.Permission, JsonConvert.SerializeObject(permission)));
            }

            return identity;
        }

        private ICollection<PermissionDto> GetAllowedPermissions(ICollection<PermissionDto> permissions)
        {
            return permissions.Where(p => p.Authorizations.Any(a => a.Allowed && !a.Denied)).ToList();
        }
    }
}