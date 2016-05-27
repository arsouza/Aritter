using Aritter.Application.DTO;

namespace Aritter.Application.Seedwork.SecurityModule.Services
{
    public interface IAuthenticationAppService : IAppService
    {
        AuthorizationDto Authenticate(string userName, string password);
        AuthorizationDto GetAuthorization(string userName);
    }
}