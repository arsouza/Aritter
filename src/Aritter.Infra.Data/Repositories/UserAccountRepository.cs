using Aritter.Domain.SecurityModule.Aggregates;
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
                .Include(p => p.Profile)
                .FirstOrDefault(p => p.Id == id);
        }

        public UserAccount Get(string username)
        {
            return UnitOfWork
                .Set<UserAccount>()
                .Include(p => p.Profile)
                .FirstOrDefault(p => p.Username == username);
        }

        public override UserAccount Get(ISpecification<UserAccount> specification)
        {
            return UnitOfWork
                .Set<UserAccount>()
                .Include(p => p.Profile)
                .FirstOrDefault(specification.SatisfiedBy());
        }

        public UserAccount FindUserAuthorizations(ISpecification<UserAccount> specification)
        {
            var user = UnitOfWork
                .Set<UserAccount>()
                .AsNoTracking()
                .Include(p => p.Profile)
                .Include(p => p.Roles)
                    .ThenInclude(p => p.Role)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Resource)
                    .ThenInclude(p => p.Client)
                .Include(p => p.Roles)
                    .ThenInclude(p => p.Role)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Rule)
                .FirstOrDefault(specification.SatisfiedBy());

            return user;
        }
    }
}
