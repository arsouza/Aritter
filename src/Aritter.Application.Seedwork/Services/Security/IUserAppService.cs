using Aritter.Application.DTO.Security;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IUserAppService : IAppService
    {
        UserDTO Authenticate(string userName, string password);
        UserDTO GetAuthorizations(string userName);
    }
}