using Aritter.Application.DTO.SecurityModule;
using System.Collections.Generic;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IUserAppService : IAppService
    {
        AuthenticationDto AuthenticateUser(AuthenticateUserDto authenticateUser);
        UserDto AddUser(AddUserDto addUser);
        UserDto GetUser(GetUserDto getUser);
        ICollection<PermissionDto> ListPermissions(UserDto user);
    }
}
