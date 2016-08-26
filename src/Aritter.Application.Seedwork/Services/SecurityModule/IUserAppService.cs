using Aritter.Application.DTO.SecurityModule;

namespace Aritter.Application.Seedwork.Services.SecurityModule
{
    public interface IUserAppService : IAppService
    {
        UserAccountDto AddUserAccount(AddUserAccountDto userAccountDto);
        UserAccountDto GetUserAccount(GetUserAccountDto userAccountDto);
    }
}
