using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Seedwork.Specification;
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

        #endregion

        public User GetAuthorizations(ISpecification<User> specification)
        {
            var query = Find(specification)
                .Include(u => u.Roles.Select(r => r.Role.Authorizations.Select(a => a.Permission.Feature.Module)))
                .Select(u => new
                {
                    u.UserName,
                    u.FirstName,
                    u.LastName,
                    u.Guid,
                    Roles = u.Roles.Select(r => new
                    {
                        Role = new
                        {
                            r.Role.Name,
                            Authorizations = r.Role.Authorizations.Where(a => a.Allowed && !a.Denied).Select(a => new
                            {
                                Permission = new
                                {
                                    a.Permission.Rule,
                                    Feature = new
                                    {
                                        Module = new
                                        {
                                            a.Permission.Feature.Module.Name
                                        },
                                        a.Permission.Feature.Name
                                    }
                                }
                            })
                        }
                    })
                })
                .FirstOrDefault();

            if (query == null)
            {
                return null;
            }

            return new User
            {
                UserName = query.UserName,
                FirstName = query.FirstName,
                LastName = query.LastName,
                Guid = query.Guid,
                Roles = query.Roles.Select(r => new UserRole
                {
                    Role = new Role
                    {
                        Name = r.Role.Name,
                        Authorizations = r.Role.Authorizations.Select(a => new Authorization
                        {
                            Permission = new Permission
                            {
                                Rule = a.Permission.Rule,
                                Feature = new Feature
                                {
                                    Name = a.Permission.Feature.Name,
                                    Module = new Module
                                    {
                                        Name = a.Permission.Feature.Module.Name
                                    }
                                }
                            }
                        }).ToList()
                    }
                }).ToList()
            };
        }

        public User GetUserPassword(ISpecification<User> specification)
        {
            var query = Find(specification)
                .Include(u => u.PasswordHistory)
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
