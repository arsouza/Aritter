using Aritter.Application.DTO.Security;
using System.Threading.Tasks;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IUserAppService : IAppService
    {
        Task<UserDTO> AuthenticateAsync(string userName, string password);
        Task<UserDTO> GetAuthorizationsAsync(string userName);
    }
}