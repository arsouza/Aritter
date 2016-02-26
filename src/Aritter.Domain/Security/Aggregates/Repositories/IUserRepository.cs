using Aritter.Domain.Seedwork.Aggregates;
using Aritter.Domain.Seedwork.Specification;

namespace Aritter.Domain.Security.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        User GetAuthenticationData(ISpecification<User> specification);
    }
}
