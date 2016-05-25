using Aritter.Application.DTO;

namespace Aritter.Application.Seedwork.SecurityModule.Services
{
    public interface IAuthenticationAppService : IAppService
    {
        AuthenticationDto Authenticate(string userName, string password);
    }
}