using Aritter.Domain.Aggregates.Security;
using Aritter.Domain.Seedwork.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Domain.Services.Security
{
    public interface IUserDomainService : IDomainService
    {
        Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType);
    }
}
