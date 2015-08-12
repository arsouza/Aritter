using Aritter.API.Models;
using Aritter.Application.Managers;
using Aritter.Infrastructure.Injection;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.API.Providers
{
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
	{
		private readonly string publicClientId;
		private readonly IUserManager userManager;

		public ApplicationOAuthProvider()
		{
			userManager = DependencyProvider.Instance.Container.GetInstance<IUserManager>();
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			var userAppManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

			ApplicationUser user = await userAppManager.FindAsync(context.UserName, context.Password);

			if (user == null)
			{
				context.SetError("invalid_grant", "The user name or password is incorrect.");
				return;
			}

			ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userAppManager, OAuthDefaults.AuthenticationType);
			ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userAppManager, CookieAuthenticationDefaults.AuthenticationType);

			AuthenticationProperties properties = CreateProperties(user.UserName);
			AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
			context.Validated(ticket);
			context.Request.Context.Authentication.SignIn(cookiesIdentity);
		}

		public override Task TokenEndpoint(OAuthTokenEndpointContext context)
		{
			foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
			{
				context.AdditionalResponseParameters.Add(property.Key, property.Value);
			}

			return Task.FromResult<object>(null);
		}

		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			// Resource owner password credentials does not provide a client ID.
			if (context.ClientId == null)
			{
				context.Validated();
			}

			return Task.FromResult<object>(null);
		}

		public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
		{
			if (context.ClientId == publicClientId)
			{
				Uri expectedRootUri = new Uri(context.Request.Uri, "/");

				if (expectedRootUri.AbsoluteUri == context.RedirectUri)
				{
					context.Validated();
				}
			}

			return Task.FromResult<object>(null);
		}

		public override Task ValidateTokenRequest(OAuthValidateTokenRequestContext context)
		{
			return base.ValidateTokenRequest(context);
		}

		public override Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
		{
			return base.AuthorizationEndpointResponse(context);
		}

		public override Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
		{
			return base.AuthorizeEndpoint(context);
		}

		public override Task GrantAuthorizationCode(OAuthGrantAuthorizationCodeContext context)
		{
			return base.GrantAuthorizationCode(context);
		}

		public override Task GrantClientCredentials(OAuthGrantClientCredentialsContext context)
		{
			return base.GrantClientCredentials(context);
		}

		public override Task GrantCustomExtension(OAuthGrantCustomExtensionContext context)
		{
			return base.GrantCustomExtension(context);
		}

		public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
		{
			return base.GrantRefreshToken(context);
		}

		public override Task TokenEndpointResponse(OAuthTokenEndpointResponseContext context)
		{
			return base.TokenEndpointResponse(context);
		}

		public override Task MatchEndpoint(OAuthMatchEndpointContext context)
		{
			return base.MatchEndpoint(context);
		}

		public override Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
		{
			return base.ValidateAuthorizeRequest(context);
		}

		public static AuthenticationProperties CreateProperties(string userName)
		{
			IDictionary<string, string> data = new Dictionary<string, string>
			{
				{ "userName", userName }
			};
			return new AuthenticationProperties(data);
		}
	}
}