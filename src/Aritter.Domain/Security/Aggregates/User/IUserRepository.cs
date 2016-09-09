using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specs;

namespace Aritter.Domain.Security.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        User Get(string username);
        User FindUserAuthorizations(ISpecification<User> specification);
    }
}
