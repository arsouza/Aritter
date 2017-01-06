using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.API.Seedwork.Security.Providers
{
    public interface IIdentityProvider
    {
        Task<ClaimsIdentity> ResolveIdentity(IdentityProviderContext context);
    }
}
