﻿using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.Seedwork.Services.SecurityModule;
using Aritter.Infra.Crosscutting.Exceptions;
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
                    Id = int.Parse(newIdentity.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.Name).Value)
                };

                var permissions = authenticationAppService.ListUserAuthorizations(userAccountDto);

                if (permissions == null)
                {
                    return;
                }

                var identity = GenerateUserIdentity(userAccountDto, permissions, OAuthDefaults.AuthenticationType);
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
                    var authenticationUserDto = new UserDto
                    {
                        Username = context.UserName,
                        Password = context.Password
                    };

                    var authentication = authenticationAppService.AuthenticateUser(authenticationUserDto);

                    if (!authentication.IsAuthenticated)
                    {
                        ThrowHelper.ThrowApplicationException(authentication.Errors);
                    }

                    var permissions = authenticationAppService.ListUserAuthorizations(authentication.User);

                    var identity = GenerateUserIdentity(authentication.User, permissions, OAuthDefaults.AuthenticationType);
                    var properties = GenerateUserProperties(authentication.User, permissions);

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

        private AuthenticationProperties GenerateUserProperties(UserAccountDto userAccount, ICollection<AuthorizationDto> authorizations)
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string>());

            return properties;
        }

        private ClaimsIdentity GenerateUserIdentity(UserAccountDto userAccount, ICollection<AuthorizationDto> authorizations, string authenticationType)
        {
            var identity = new ClaimsIdentity(authenticationType);

            identity.AddClaim(new Claim(ClaimTypes.Name, userAccount.Username));
            identity.AddClaim(new Claim(Infra.Web.Security.ClaimTypes.UserId, userAccount.Id.ToString(), ClaimValueTypes.Integer));
            identity.AddClaim(new Claim(Infra.Web.Security.ClaimTypes.UniqueIdentifier, userAccount.UID.ToString()));

            foreach (var authorization in authorizations)
            {
                identity.AddClaim(new Claim(Infra.Web.Security.ClaimTypes.Permission, $"{authorization.Application}:{authorization.Resource}:{authorization.Operation}"));
            }

            return identity;
        }
    }
}