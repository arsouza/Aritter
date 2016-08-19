using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        #region Constructors

        public PermissionRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public ICollection<Permission> ListPermissions(ISpecification<Permission> specification)
        {
            var permissions = UnitOfWork
                .Set<Permission>()
                .AsNoTracking()
                .Include(p => p.Authorizations)
                    .ThenInclude(a => a.UserRole)
                    .ThenInclude(r => r.UserAssignments)
                    .ThenInclude(r => r.UserAccount)
                .Include(p => p.Resource)
                    .ThenInclude(r => r.Application)
                .Include(p => p.Operation)
                    .ThenInclude(r => r.Application)
                .Where(specification.SatisfiedBy())
                .ToList();

            return permissions;
        }

        #endregion
    }
}
