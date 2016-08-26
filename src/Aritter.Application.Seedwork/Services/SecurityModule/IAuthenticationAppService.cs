using Aritter.Application.DTO.SecurityModule.Authentication;
using System.Collections.Generic;

namespace Aritter.Application.Seedwork.Services.SecurityModule
{
    public interface IAuthenticationAppService : IAppService
    {
        AuthenticationDto AuthenticateUser(UserDto serDto);
        ICollection<AuthorizationDto> ListUserAuthorizations(UserAccountDto userAccountDto);
    }
}