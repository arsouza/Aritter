using System;
using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.UnitOfWork;
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
            var user = Find(p => p.UserName == userName)
                  .Include(p => p.PasswordHistory)
                  .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            var password = user.PasswordHistory.LastOrDefault();

            if (password.PasswordHash != passwordHash)
            {
                return null;
            }

            return new User
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

        #endregion
    }
}
