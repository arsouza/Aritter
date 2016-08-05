using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specs;

namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        UserAccount FindAuthorizations(ISpecification<UserAccount> specification);
    }
}
