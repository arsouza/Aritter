using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Security.Aggregates
{
    public interface IUserRepository : IRepository<User>
    {
        User GetAuthenticationData(string userName);
    }
}
