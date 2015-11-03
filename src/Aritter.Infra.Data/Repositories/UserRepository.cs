using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.UnitOfWork;

namespace Aritter.Infra.Data.Repository
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructors

        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
