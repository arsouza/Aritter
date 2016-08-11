using Aritter.Application.DTO.SecurityModule.Authentication;

namespace Aritter.Application.Seedwork.Services.SecurityModule
{
	public interface IAuthenticationAppService : IAppService
	{
		AuthenticationDto AuthenticateUser(AuthenticationUserDto authenticationUserDto);
		AuthorizationDto GetUserAuthorization(UserAccountDto userAccountDto);
	}
}