using Aritter.Domain.SecurityModule.Aggregates;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Domain.SecurityModule.Services
{
    public interface IAuthenticationDomainService : IDomainService
    {
        Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType);
    }
}
