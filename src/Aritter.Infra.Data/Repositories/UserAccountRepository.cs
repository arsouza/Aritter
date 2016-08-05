using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Aritter.Infra.Data.Repositories
{
    public sealed class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        #region Constructors

        public UserAccountRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        public override UserAccount Get(int id)
        {
            return UnitOfWork
                .Set<UserAccount>()
                .Include(p => p.UserProfile)
                .First(p => p.Id == id);
        }

        public override UserAccount Get(ISpecification<UserAccount> specification)
        {
            return UnitOfWork
                .Set<UserAccount>()
                .Include(p => p.UserProfile)
                .FirstOrDefault(specification.SatisfiedBy());
        }

        public UserAccount FindAuthorizations(ISpecification<UserAccount> specification)
        {
            var user = UnitOfWork
                .Set<UserAccount>()
                .AsNoTracking()
                .Include(p => p.UserProfile)
                .Include(p => p.Assignments)
                    .ThenInclude(p => p.UserRole)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Resource)
                    .ThenInclude(p => p.Application)
                .Include(p => p.Assignments)
                    .ThenInclude(p => p.UserRole)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Operation)
                .FirstOrDefault(specification.SatisfiedBy());

            return user;
        }

        public ICollection<UserAssignment> FindAllowedAssigns(ISpecification<UserAssignment> specification)
        {
            var assigns = UnitOfWork
                .Set<UserAssignment>()
                .AsNoTracking()
                .Include(p => p.UserRole)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Resource)
                    .ThenInclude(p => p.Application)
                .Include(p => p.UserRole)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Operation)
                    .ThenInclude(p => p.Application)
                .Where(specification.SatisfiedBy())
                .ToList();

            return assigns;
        }
    }
}
