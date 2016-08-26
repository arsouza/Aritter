using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Data.Repositories
{
    public class AuthorizationRepository : Repository<Authorization>, IAuthorizationRepository
    {
        #region Constructors

        public AuthorizationRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public ICollection<Authorization> ListAuthorizations(ISpecification<Authorization> specification)
        {
            var permissions = UnitOfWork
                .Set<Authorization>()
                .AsNoTracking()
                .Include(a => a.UserRole)
                    .ThenInclude(r => r.UserAssignments)
                    .ThenInclude(r => r.UserAccount)
                .Include(p => p.Permission)
                    .ThenInclude(p => p.Resource)
                    .ThenInclude(r => r.Client)
                .Include(p => p.Permission)
                    .ThenInclude(p => p.Operation)
                    .ThenInclude(r => r.Client)
                .Where(specification.SatisfiedBy())
                .ToList();

            return permissions;
        }

        #endregion
    }
}
