using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Principal;
using Aritter.API.Seedwork.Security.Providers;

namespace Aritter.Security.API.Core.Providers
{
    internal sealed class JwtIdentityProvider : IIdentityProvider
    {
        public Task<ClaimsIdentity> ResolveIdentity(IdentityProviderContext context)
        {
            // Don't do this in production, obviously!
            if (context.Username == "TEST" && context.Password == "TEST123")
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(context.Username, "Claims"), new Claim[] { }));
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
