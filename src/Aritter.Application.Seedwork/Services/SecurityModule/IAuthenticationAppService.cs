using Aritter.Application.DTO.SecurityModule.Authentication;

namespace Aritter.Application.Seedwork.Services.SecurityModule
{
    public interface IAuthenticationAppService : IAppService
	{
		AuthenticationDto Authenticate(string userName, string password);
		AuthenticationDto GetAuthorization(string userName);
	}
}