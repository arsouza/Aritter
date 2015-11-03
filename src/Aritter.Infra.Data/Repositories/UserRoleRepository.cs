using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.UnitOfWork;

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

