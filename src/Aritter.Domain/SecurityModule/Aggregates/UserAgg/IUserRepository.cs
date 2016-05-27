using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public interface IUserRepository : IRepository<User>
    {
        User GetAuthorizations(ISpecification<User> specification);
    }
}
