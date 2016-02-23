using Aritter.Domain.Aggregates.Security;
using Aritter.Domain.Seedwork.UnitOfWork;
using System.Data.Entity;
using System.Linq;

namespace Aritter.Infra.Data.Repository
{
    public sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        #region Constructors

        public UserRoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IQueryable<UserRole> GetRolesByUserId(int userId)
        {
            return Find()
                .Include(p => p.Role)
                .Where(p => p.UserId == userId);
        }

        #endregion
    }
}