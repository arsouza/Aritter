using Aritter.Domain.Seedwork.Specs;
using System.Linq;

namespace Aritter.Domain.Security.Aggregates.Specs
{
    public static class PermissionSpecs
    {
        public static Specification<Permission> FromUser(string username)
        {
            return new DirectSpecification<Permission>(p => p.Authorizations.Any(a => a.Role.Members.Any(ua => ua.User.Username == username)));
        }

        public static Specification<Permission> FromUser(int userId)
        {
            return new DirectSpecification<Permission>(p => p.Authorizations.Any(a => a.Role.Members.Any(ua => ua.UserId == userId)));
        }
    }
}
