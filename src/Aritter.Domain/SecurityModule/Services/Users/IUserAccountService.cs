using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.Seedwork.Services;

namespace Aritter.Domain.SecurityModule.Services.Users
{
    public interface IUserAccountService : IDomainService
    {
        void SaveUserAccount(UserAccount userAccount);
    }
}
