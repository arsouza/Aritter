using Aritter.Application.DTO.SecurityModule;
using System.Collections.Generic;

namespace Aritter.Application.Seedwork.Services.SecurityModule
{
    public interface IAuthenticationAppService : IAppService
    {
        AuthenticationDto AuthenticateUser(AuthenticateUserDto serDto);
        ICollection<AuthorizationDto> ListUserAuthorizations(UserAccountDto userAccountDto);
    }
}