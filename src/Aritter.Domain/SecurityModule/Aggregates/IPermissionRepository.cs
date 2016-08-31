using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specs;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        ICollection<Permission> ListPermissions(ISpecification<Permission> specification);
    }
}
