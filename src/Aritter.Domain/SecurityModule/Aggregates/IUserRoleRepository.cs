using Aritter.Domain.Contracts;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        IQueryable<UserRole> GetRolesByUserId(int id);
    }
}
