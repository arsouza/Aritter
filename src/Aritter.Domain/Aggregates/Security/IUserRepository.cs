using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Aggregates.Security
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUsernameAndPassword(string userName, string password);
    }
}
