using Aritter.Domain.Seedwork.Aggregates;
using Aritter.Domain.Seedwork.Specification;

namespace Aritter.Domain.Security.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        User GetAuthorizations(ISpecification<User> specification);
        User GetUserPassword(ISpecification<User> specification);
    }
}
