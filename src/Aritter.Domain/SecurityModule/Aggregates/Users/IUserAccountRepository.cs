using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specs;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates.Users
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        ICollection<UserAssignment> FindAllowedAssigns(ISpecification<UserAssignment> specification);
    }
}
