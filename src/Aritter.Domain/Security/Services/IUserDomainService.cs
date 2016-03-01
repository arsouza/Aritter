using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.Services;
using System.Threading.Tasks;

namespace Aritter.Domain.Security.Services
{
    public interface IUserDomainService : IDomainService
    {
        Task<User> AuthenticateAsync(string userName, string password);
        Task<User> GetUserAsync(string userName);
    }
}
