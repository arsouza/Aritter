using Aritter.Domain.Seedwork.Specs;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions.Specs
{
    public static class AuthorizationSpecs
    {
        public static Specification<Authorization> FromUserAccount(string username)
        {
            return new DirectSpecification<Authorization>(p => p.UserRole.UserAssignments.Any(ua => ua.UserAccount.Username == username));
        }

        public static Specification<Authorization> HasAllowed()
        {
            return new DirectSpecification<Authorization>(p => p.Allowed && !p.Denied);
        }
    }
}
