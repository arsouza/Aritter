﻿using Aritter.Application.Managers;
using Aritter.Infra.IoC.Providers;
using Aritter.Web.Api.Core.Filters;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Web.Api.Core.Providers
{
	[AritterExceptionFilter]
	public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
	{
		private readonly IUserManager userManager;
		private readonly string publicClientId;

		public ApplicationOAuthProvider(string publicClientId)
		{
			this.publicClientId = publicClientId;
			userManager = ServiceProvider.Get<IUserManager>();
		}

		public static AuthenticationProperties CreateProperties(string userName)
		{
			IDictionary<string, string> data = new Dictionary<string, string>
			{
				{ "userName", userName }
			};
			return new AuthenticationProperties(data);
		}

		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			try
			{
				var user = await userManager.FindAsync(context.UserName, context.Password);

				if (user == null)
				{
					context.SetError("invalid_grant", "The user name or password is incorrect.");
					return;
				}

				ClaimsIdentity oAuthIdentity = await userManager.GenerateUserIdentityAsync(user, OAuthDefaults.AuthenticationType);
				ClaimsIdentity cookiesIdentity = await userManager.GenerateUserIdentityAsync(user, CookieAuthenticationDefaults.AuthenticationType);

				AuthenticationProperties properties = CreateProperties(user.UserName);
				AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
				context.Validated(ticket);
				context.Request.Context.Authentication.SignIn(cookiesIdentity);
			}
			catch (Exception ex)
			{
				context.SetError("application_error", ex.ToString());
			}
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
	}
}