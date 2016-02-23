using Aritter.Domain.Seedwork.Aggregates;
using System.Linq;

namespace Aritter.Domain.Aggregates.Security
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        IQueryable<UserRole> GetRolesByUserId(int id);
    }
}
