using Aritter.Application.DTO.SecurityModule;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IUserAppService : IAppService
    {
        UserDto AddUser(AddUserDto addUser);
        UserDto GetUser(GetUserDto getUser);
    }
}
