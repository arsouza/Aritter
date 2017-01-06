using System;
using System.Text;
using Aritter.API.Seedwork.Security.Providers;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Aritter.Security.API.Core.Providers;

namespace Aritter.Security.API
{
    internal partial class Startup
    {
        private const string SecretKey = "E8E2AB68-C405-4AD1-8063-E05ACD6FDCE9";

        private void ConfigureAuth(IApplicationBuilder app)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

            app.UseJwtProvider(new JwtProviderOptions
            {
                Path = "/api/token",
                Audience = "ExampleAudience",
                Issuer = "ExampleIssuer",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityProvider = new JwtIdentityProvider(),
                Expiration = TimeSpan.FromDays(1)
            });

            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = new TokenValidationParameters
                {
                    // The signing key must match!
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,

                    // Validate the JWT Issuer (iss) claim
                    ValidateIssuer = true,
                    ValidIssuer = "ExampleIssuer",

                    // Validate the JWT Audience (aud) claim
                    ValidateAudience = true,
                    ValidAudience = "ExampleAudience",

                    // Validate the token expiry
                    ValidateLifetime = true,

                    // If you want to allow a certain amount of clock drift, set that here:
                    ClockSkew = TimeSpan.Zero
                }
            });
        }
    }
}
