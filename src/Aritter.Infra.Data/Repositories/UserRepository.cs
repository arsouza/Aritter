using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork.Specifications;
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
                .Include(p => p.Person)
                .First(p => p.Id == id);
        }

        public override User Get(ISpecification<User> specification)
        {
            return UnitOfWork
                .Set<User>()
                .Include(p => p.Person)
                .First(specification.SatisfiedBy());
        }

        public User FindAuthorizations(ISpecification<User> specification)
        {
            var user = UnitOfWork
                .Set<User>()
                .AsNoTracking()
                .Include(p => p.Person)
                .Include(p => p.UserAssignments)
                    .ThenInclude(p => p.Role)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Resource)
                    .ThenInclude(p => p.Application)
                .Include(p => p.UserAssignments)
                    .ThenInclude(p => p.Role)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Operation)
                .FirstOrDefault(specification.SatisfiedBy());

            return user;
        }
    }
}
