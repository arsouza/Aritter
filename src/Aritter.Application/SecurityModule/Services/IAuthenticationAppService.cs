using Aritter.Application.Contracts;
using Aritter.Domain.SecurityModule.Aggregates;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Application.SecurityModule.Services
{
    public interface IAuthenticationAppService : IAppService
    {
        Task<User> FindAsync(string userName, string password);
        Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType);
    }
}