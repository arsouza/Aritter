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

        public User GetUserClaims(ISpecification<User> specification)
        {
            var query = Find(specification)
                .Include(u => u.Roles.Select(r => r.Role.Authorizations.Select(a => a.Permission.Resource)))
                .Include(u => u.Authorizations.Select(a => a.Permission.Resource))
                .Select(u => new
                {
                    u.UserName,
                    u.FirstName,
                    u.LastName,
                    u.Guid,
                    Authorizations = u.Authorizations.Select(a => new
                    {
                        a.Allowed,
                        a.Denied,
                        Permission = new
                        {
                            a.Permission.Rule,
                            Resource = new
                            {
                                a.Permission.Resource.Name
                            }
                        }
                    }),
                    Roles = u.Roles.Select(r => new
                    {
                        Role = new
                        {
                            r.Role.Name,
                            Authorizations = r.Role.Authorizations.Select(a => new
                            {
                                a.Allowed,
                                a.Denied,
                                Permission = new
                                {
                                    a.Permission.Rule,
                                    Resource = new
                                    {
                                        a.Permission.Resource.Name
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
                Authorizations = query.Authorizations.Select(a => new Authorization
                {
                    Allowed = a.Allowed,
                    Denied = a.Denied,
                    Permission = new Permission
                    {
                        Rule = a.Permission.Rule,
                        Resource = new Resource
                        {
                            Name = a.Permission.Resource.Name
                        }
                    }
                }).ToList(),
                Roles = query.Roles.Select(r => new UserRole
                {
                    Role = new Role
                    {
                        Name = r.Role.Name,
                        Authorizations = r.Role.Authorizations.Select(a => new Authorization
                        {
                            Allowed = a.Allowed,
                            Denied = a.Denied,
                            Permission = new Permission
                            {
                                Rule = a.Permission.Rule,
                                Resource = new Resource
                                {
                                    Name = a.Permission.Resource.Name
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
                    PasswordHistory = u.PasswordHistory.Select(ph => ph.PasswordHash)
                })
                .FirstOrDefault();

            if (query == null)
            {
                return null;
            }

            var user = new User
            {
                PasswordHistory = query.PasswordHistory.Select(ph => new UserPassword { PasswordHash = ph }).ToList()
            };

            return user;
        }
    }
}
