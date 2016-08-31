using Aritter.Domain.Seedwork.Specs;
using System.Linq;

namespace Aritter.Domain.SecurityModule.Aggregates.Specs
{
    public static class PermissionSpecs
    {
        public static Specification<Permission> FromUserAccount(string username)
        {
            return new DirectSpecification<Permission>(p => p.Authorizations.Any(a => a.Role.Members.Any(ua => ua.Member.Username == username)));
        }

        public static Specification<Permission> FromUserAccount(int accountId)
        {
            return new DirectSpecification<Permission>(p => p.Authorizations.Any(a => a.Role.Members.Any(ua => ua.MemberId == accountId)));
        }
    }
}
