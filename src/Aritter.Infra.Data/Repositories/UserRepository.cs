using Aritter.Domain.SecurityModule.Aggregates.MainAgg;
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
                .Where(specification.SatisfiedBy())
                .Select(u => new User
                {
                    Username = u.Username,
                    Identity = u.Identity,
                    Person = new Person
                    {
                        FirstName = u.Person.FirstName
                    }
                    //UserRoles = u.UserRoles.Select(r => new
                    //{
                    //    Role = new
                    //    {
                    //        r.Role.Name,
                    //        Authorizations = r.Role.Authorizations.Where(a => a.Allowed && !a.Denied).Select(a => new
                    //        {
                    //            a.Allowed,
                    //            a.Denied,
                    //            Permission = new
                    //            {
                    //                a.Permission.Rule,
                    //                Resource = new
                    //                {
                    //                    Module = new
                    //                    {
                    //                        a.Permission.Resource.Module.Name
                    //                    },
                    //                    a.Permission.Resource.Name
                    //                }
                    //            }
                    //        })
                    //    }
                    //})
                })
                .FirstOrDefault();

            return user;
        }

        public User GetWithPassword(ISpecification<User> specification)
        {
            var user = ((IQueryableUnitOfWork)UnitOfWork)
                .Set<User>()
                .Include(u => u.Credential)
                .FirstOrDefault(specification.SatisfiedBy());

            return user;
        }
    }
}
