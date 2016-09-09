using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.Specs;
using Aritter.Infra.Data.Seedwork;
using Microsoft.EntityFrameworkCore;
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

        public override User Get(int id)
        {
            return UnitOfWork
                .Set<User>()
                .Include(p => p.Profile)
                .FirstOrDefault(p => p.Id == id);
        }

        public User Get(string username)
        {
            return UnitOfWork
                .Set<User>()
                .Include(p => p.Profile)
                .FirstOrDefault(p => p.Username == username);
        }

        public override User Get(ISpecification<User> specification)
        {
            return UnitOfWork
                .Set<User>()
                .Include(p => p.Profile)
                .FirstOrDefault(specification.SatisfiedBy());
        }

        public User FindUserAuthorizations(ISpecification<User> specification)
        {
            return null;
        }
    }
}
