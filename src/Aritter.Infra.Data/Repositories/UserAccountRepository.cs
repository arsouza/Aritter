using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
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
                .FirstOrDefault(p => p.Id == id);
        }

        public UserAccount Get(string username)
        {
            return UnitOfWork
                .Set<UserAccount>()
                .Include(p => p.UserProfile)
                .FirstOrDefault(p => p.Username == username);
        }

        public override UserAccount Get(ISpecification<UserAccount> specification)
        {
            return UnitOfWork
                .Set<UserAccount>()
                .Include(p => p.UserProfile)
                .FirstOrDefault(specification.SatisfiedBy());
        }

        public UserAccount FindUserAuthorizations(ISpecification<UserAccount> specification)
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
    }
}
