using Aritter.Security.Domain.Users.Aggregates;
using Aritter.Infra.Data.Seedwork;

namespace Aritter.Security.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
