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

        public User GetWithAuthorizations(ISpecification<User> specification)
        {
            var user = ((IQueryableUnitOfWork)UnitOfWork)
                .Set<User>()
                .Include(u => u.UserRoles)
                    .ThenInclude(p => p.Role)
                    .ThenInclude(p => p.Authorizations)
                    .ThenInclude(p => p.Permission)
                    .ThenInclude(p => p.Resource)
                    .ThenInclude(p => p.Module)
                .Where(specification.SatisfiedBy())
                .Select(u => new
                {
                    u.UserName,
                    u.FirstName,
                    u.LastName,
                    u.Identity,
                    UserRoles = u.UserRoles.Select(r => new
                    {
                        Role = new
                        {
                            r.Role.Name,
                            Authorizations = r.Role.Authorizations.Where(a => a.Allowed && !a.Denied).Select(a => new
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
                        }
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
            var user = ((IQueryableUnitOfWork)UnitOfWork)
                .Set<User>()
                  .Include(u => u.PreviousCredentials)
                  .Where(specification.SatisfiedBy())
                  .Select(u => new
                  {
                      Credentials = u.PreviousCredentials.Select(ph => new
                      {
                          ph.PasswordHash
                      })
                  })
                  .FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            return typeAdapter.Adapt<User>(user);
        }
    }
}
