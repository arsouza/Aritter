using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Aritter.Infra.Crosscutting.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aritter.API.Seedwork.Security.Providers
{
    /// <summary>
    /// Token generator middleware component which is added to an HTTP pipeline.
    /// This class is not created by application code directly,
    /// instead it is added by calling the <see cref="JwtProviderAppBuilderExtensions.UseJwtProvider(Microsoft.AspNetCore.Builder.IApplicationBuilder, JwtProviderOptions)"/>
    /// extension method.
    /// </summary>
    public class JwtProviderMiddleware
    {
        private readonly RequestDelegate next;
        private readonly JwtProviderOptions options;
        private readonly JsonSerializerSettings serializerSettings;

        public JwtProviderMiddleware(RequestDelegate next,
                                     IOptions<JwtProviderOptions> options)
        {
            this.next = next;
            this.options = options.Value;

            ThrowIfInvalidOptions(this.options);

            serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        public Task Invoke(HttpContext httpContext)
        {
            // If the request path doesn't match, skip
            if (!httpContext.Request.Path.Equals(options.Path, StringComparison.Ordinal))
            {
                return next(httpContext);
            }

            if (!httpContext.Request.Method.Equals("POST"))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Task.FromResult(httpContext.Response);
            }

            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!httpContext.Request.HasFormContentType)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Task.FromResult(httpContext.Response);
            }

            var jwtTokenContext = new IdentityProviderContext(httpContext);

            return GenerateToken(jwtTokenContext);
        }

        private async Task GenerateToken(IdentityProviderContext context)
        {
            ClaimsIdentity identity = await options.IdentityProvider.ResolveIdentity(context);

            if (identity == null)
            {
                context.HttpContext.Response.StatusCode = 400;
                await context.HttpContext.Response.WriteAsync("Invalid username or password.");
                return;
            }

            DateTime now = DateTime.UtcNow;

            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, identity.Name));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, await options.NonceGenerator()));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Iat, now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64));

            // Create the JWT and write it to a string
            JwtSecurityToken jwt = new JwtSecurityToken(options.Issuer,
                                                        options.Audience,
                                                        identity.Claims,
                                                        now,
                                                        now.Add(options.Expiration),
                                                        options.SigningCredentials);

            string encodedToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedToken,
                token_type = "bearer",
                expires_in = (int)options.Expiration.TotalSeconds
            };

            // Serialize and return the response
            context.HttpContext.Response.ContentType = "application/json";
            await context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(response, serializerSettings));
        }

        private static void ThrowIfInvalidOptions(JwtProviderOptions options)
        {
            Check.IsNotNull(options.Path, nameof(JwtProviderOptions.Path));
            Check.IsNotEmpty(options.Path, nameof(JwtProviderOptions.Path));

            Check.IsNotNull(options.Issuer, nameof(JwtProviderOptions.Issuer));
            Check.IsNotEmpty(options.Issuer, nameof(JwtProviderOptions.Issuer));

            Check.IsNotNull(options.Audience, nameof(JwtProviderOptions.Audience));
            Check.IsNotEmpty(options.Audience, nameof(JwtProviderOptions.Audience));

            Check.Against<ArgumentException>(options.Expiration == TimeSpan.Zero, "Must be a non-zero TimeSpan.", nameof(JwtProviderOptions.Expiration));
            Check.IsNotNull(options.IdentityProvider, nameof(JwtProviderOptions.IdentityProvider));
            Check.IsNotNull(options.SigningCredentials, nameof(JwtProviderOptions.SigningCredentials));
            Check.IsNotNull(options.NonceGenerator, nameof(JwtProviderOptions.NonceGenerator));
        }
    }
}
