using Aritter.Application.DTO.SecurityModule;

namespace Aritter.Application.Seedwork.Services.SecurityModule
{
    public interface IUserAppService : IAppService
    {
        UserAccountDto AddAccount(AddUserAccountDto addAccount);
        UserAccountDto GetAccount(GetUserAccountDto getAccount);
    }
}
