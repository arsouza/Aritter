using Aritter.Application.DTO.SecurityModule;
using System.Collections.Generic;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IAuthenticationAppService : IAppService
    {
        AuthenticationDto AuthenticateUser(AuthenticateUserDto authenticateUser);
        ICollection<PermissionDto> ListUserPermissions(UserDto user);
    }
}