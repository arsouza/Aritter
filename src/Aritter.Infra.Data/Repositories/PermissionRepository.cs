using Aritter.Domain.SecurityModule.Aggregates;
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
                .Include(p => p.Operation)
                .Include(p => p.Resource)
                .Include(p => p.Authorizations)
                    .ThenInclude(a => a.Role)
                    .ThenInclude(ur => ur.Members)
                .Where(p => p.Operation.ClientId == p.Resource.ClientId)
                .Where(specification.SatisfiedBy())
                .ToList();

            return permissions;
        }

        #endregion
    }
}
