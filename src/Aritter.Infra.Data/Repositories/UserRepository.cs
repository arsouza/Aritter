using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Data.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructors

        public UserRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        public ICollection<UserRole> FindPermissions(ISpecification<UserRole> specification)
        {
            var roles = ((IQueryableUnitOfWork)UnitOfWork)
                .Set<UserRole>()
                .AsNoTracking()
                .Include(p => p.Role)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Resource)
                    .ThenInclude(p => p.Module)
                    .ThenInclude(p => p.Menus)
                .Where(specification.SatisfiedBy())
                .ToList();

            return roles;
        }

        public User GetWithCredentials(ISpecification<User> specification)
        {
            var user = ((IQueryableUnitOfWork)UnitOfWork)
                .Set<User>()
                .Include(u => u.Person)
                .Include(u => u.Credential)
                .FirstOrDefault(specification.SatisfiedBy());

            return user;
        }
    }
}
