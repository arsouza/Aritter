using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;

namespace Aritter.Domain.Security.Aggregates.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetAuthorizations(ISpecification<User> specification);
        User GetUserPassword(ISpecification<User> specification);
    }
}
