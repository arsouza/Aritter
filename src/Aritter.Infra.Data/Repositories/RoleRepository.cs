using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Infra.Data.Seedwork;

namespace Aritter.Infra.Data.Repositories
{
    public sealed class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
