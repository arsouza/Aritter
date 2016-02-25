using Aritter.Domain.Aggregates.Security;
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

        public User FindByUsernameAndPassword(string userName, string passwordHash)
        {
            var user = Find(UsersSpecifications.UserByUserName(userName))
                  .Include(p => p.PasswordHistory)
                  .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return new User
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHistory = user.PasswordHistory
            };
        }

        #endregion
    }
}
