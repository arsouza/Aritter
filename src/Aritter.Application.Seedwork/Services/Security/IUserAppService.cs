using Aritter.Application.DTO.SecurityModule;

namespace Aritter.Application.Seedwork.Services.Security
{
    public interface IUserAppService : IAppService
    {
        UserAccountDto AddAccount(AddUserAccountDto addAccount);
        UserAccountDto GetAccount(GetUserAccountDto getAccount);
    }
}
