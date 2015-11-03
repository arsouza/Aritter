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
            var user = Find(p => p.UserName == userName)
                  .Include(p => p.PasswordHistory)
                  .Select(p => new { Id = p.Id, UserName = p.UserName, Password = p.PasswordHistory.OrderByDescending(x => x.Date).FirstOrDefault() })
                  .FirstOrDefault();

            if (user == null || user.Password == null || user.Password.PasswordHash != password)
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
