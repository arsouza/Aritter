using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.Specification;
using Aritter.Domain.Seedwork.UnitOfWork;
using Aritter.Infra.Data.SeedWork.Repository;
using System.Data.Entity;
using System.Linq;

namespace Aritter.Infra.Data.Repository
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructors

        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        public User GetAuthenticationData(ISpecification<User> specification)
        {
            return Find(specification)
                .Include(p => p.PasswordHistory)
                .Include(p => p.UserRoles)
                .Include(p => p.UserRoles.Select(r => r.Role))
                .FirstOrDefault();
        }
    }
}
