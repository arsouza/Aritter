using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Users;
using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Data.Seedwork;
using System.Data.Entity;
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

        public User GetAuthorizations(ISpecification<User> specification)
        {
            var user = ((IQueryableUnitOfWork)UnitOfWork)
                .Set<User>()
                .Include(u => u.Roles.Select(r => r.Authorizations.Select(a => a.Permission.Resource.Module)))
                .Where(specification.SatisfiedBy())
                .Select(u => new
                {
                    u.UserName,
                    u.FirstName,
                    u.LastName,
                    u.Identity,
                    Roles = u.Roles.Select(r => new
                    {
                        r.Name,
                        Authorizations = r.Authorizations.Where(a => a.Allowed && !a.Denied).Select(a => new
                        {
                            a.Allowed,
                            a.Denied,
                            Permission = new
                            {
                                a.Permission.Rule,
                                Resource = new
                                {
                                    Module = new
                                    {
                                        a.Permission.Resource.Module.Name
                                    },
                                    a.Permission.Resource.Name
                                }
                            }
                        })
                    })
                })
                .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return typeAdapter.Adapt<User>(user);
        }

        public User GetUserPassword(ISpecification<User> specification)
        {
            var query = ((IQueryableUnitOfWork)UnitOfWork)
                .Set<User>()
                .Include(u => u.PasswordHistory)
                .Where(specification.SatisfiedBy())
                .Select(u => new
                {
                    PasswordHistory = u.PasswordHistory.Select(ph => new
                    {
                        ph.PasswordHash
                    })
                })
                .FirstOrDefault();

            if (query == null)
            {
                return null;
            }

            var user = new User
            {
                PasswordHistory = query.PasswordHistory.Select(ph => new UserPassword
                {
                    PasswordHash = ph.PasswordHash
                }).ToList()
            };

            return user;
        }
    }
}
