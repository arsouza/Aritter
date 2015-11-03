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

        public User FindByUsernameAndPassword(string userName, string password)
        {
            return Find(p => p.UserName == userName)
                  .Include(p => p.PasswordHistory)
                  .FirstOrDefault(p => p.PasswordHistory.Any() && p.PasswordHistory.Last().Password == password);
        }

        #endregion
    }
}
