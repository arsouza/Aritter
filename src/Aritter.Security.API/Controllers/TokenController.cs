using Aritter.API.Models;
using Aritter.API.Seedwork.Security.Providers;
using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Infra.Crosscutting.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Aritter.API.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly JwtBearerTokenOptions jwtBearerTokenOptions;
        private readonly ILogger logger;

        public TokenController(IOptions<JwtBearerTokenOptions> jwtBearerTokenOptions, ILoggerFactory loggerFactory)
        {
            this.jwtBearerTokenOptions = jwtBearerTokenOptions.Value;
            ValidateOptions(this.jwtBearerTokenOptions);

            logger = loggerFactory.CreateLogger<TokenController>();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken([FromForm] ApplicationUser applicationUser)
        {
            var identity = await GetClaimsIdentity(applicationUser);

            if (identity == null)
            {
                logger.LogInformation($"Invalid username ({applicationUser.Username}) or password ({applicationUser.Password})");
                return BadRequest("Invalid credentials");
            }

            DateTime now = DateTime.UtcNow;

            // Specifically add the jti (nonce), iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, identity.Name));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, await jwtBearerTokenOptions.NonceGenerator()));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Iat, now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64));

            // Create the JWT and write it to a string
            JwtSecurityToken jwt = new JwtSecurityToken(jwtBearerTokenOptions.Issuer,
                                                        jwtBearerTokenOptions.Audience,
                                                        identity.Claims,
                                                        now,
                                                        now.Add(jwtBearerTokenOptions.Expiration),
                                                        jwtBearerTokenOptions.SigningCredentials);

            string encodedToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedToken,
                token_type = JwtBearerDefaults.AuthenticationScheme,
                expires_in = (int)jwtBearerTokenOptions.Expiration.TotalSeconds
            };

            return Ok(response);
        }

        private static void ValidateOptions(JwtBearerTokenOptions options)
        {
            Check.IsNotNull(options.Issuer, nameof(JwtBearerTokenOptions.Issuer));
            Check.IsNotEmpty(options.Issuer, nameof(JwtBearerTokenOptions.Issuer));

            Check.IsNotNull(options.Audience, nameof(JwtBearerTokenOptions.Audience));
            Check.IsNotEmpty(options.Audience, nameof(JwtBearerTokenOptions.Audience));

            Check.Against<ArgumentException>(options.Expiration == TimeSpan.Zero, "Must be a non-zero TimeSpan.", nameof(JwtBearerTokenOptions.Expiration));

            Check.IsNotNull(options.SigningCredentials, nameof(JwtBearerTokenOptions.SigningCredentials));
            Check.IsNotNull(options.NonceGenerator, nameof(JwtBearerTokenOptions.NonceGenerator));
        }

        /// <summary>
        /// IMAGINE BIG RED WARNING SIGNS HERE!
        /// You'd want to retrieve claims through your claims provider
        /// in whatever way suits you, the below is purely for demo purposes!
        /// </summary>
        private static Task<ClaimsIdentity> GetClaimsIdentity(ApplicationUser user)
        {
            if (user.Username == "MickeyMouse" &&
                user.Password == "MickeyMouseIsBoss123")
            {
                return Task.FromResult(new ClaimsIdentity(
                  new GenericIdentity(user.Username, "Token"),
                  new[]
                  {
                    new Claim("DisneyCharacter", "IAmMickey")
                  }));
            }

            if (user.Username == "NotMickeyMouse" &&
                user.Password == "MickeyMouseIsBoss123")
            {
                return Task.FromResult(new ClaimsIdentity(
                  new GenericIdentity(user.Username, "Token"),
                  new Claim[] { }));
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
