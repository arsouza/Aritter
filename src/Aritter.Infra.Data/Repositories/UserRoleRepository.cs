using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Infra.Data.Seedwork;

namespace Aritter.Infra.Data.Repositories
{
    public sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
