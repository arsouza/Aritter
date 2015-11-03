using System;
using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Domain.UnitOfWork;

namespace Aritter.Infra.Data.Repository
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructors

        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public User GetByUsernameAndPassword(string userName, string password)
        {
            return Get(p => p.UserName == userName && p.PasswordHash == password);
        }

        #endregion
    }
}
