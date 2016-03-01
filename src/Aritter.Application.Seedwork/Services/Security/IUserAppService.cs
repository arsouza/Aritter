using Aritter.Domain.Security.Aggregates;
using System.Threading.Tasks;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IUserAppService : IAppService
    {
        Task<User> AuthenticateAsync(string userName, string password);
        Task<User> GetUserAsync(string userName);
    }
}