using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.Services;
using System.Threading.Tasks;

namespace Aritter.Domain.Security.Services
{
    public interface IUserDomainService : IDomainService
    {
        Task<User> AuthenticateAsync(string userName, string password);
        User Authenticate(string userName, string password);
        Task<User> GetUserClaimsAsync(string userName);
        User GetUserClaims(string userName);
    }
}
