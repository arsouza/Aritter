using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.UnitOfWork;
using Aritter.Infra.Data.SeedWork.Repository;

namespace Aritter.Infra.Data.Repository
{
    public sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        #region Constructors

        public UserRoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}