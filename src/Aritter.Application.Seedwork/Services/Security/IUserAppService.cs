using Aritter.Domain.Aggregates.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IUserAppService : IAppService
    {
        Task<User> FindAsync(string userName, string password);
        Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType);
    }
}