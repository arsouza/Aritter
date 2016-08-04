using Aritter.Domain.SecurityModule.Aggregates.Modules;
using Aritter.Domain.SecurityModule.Aggregates.Users;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public static class RoleFactory
    {
        public static UserRole CreateRole(Application application, string name)
        {
            return new UserRole(application, name);
        }

        public static UserRole CreateRole(Application application, string name, string description)
        {
            return new UserRole(application, name, description);
        }

        public static UserAssignment CreateUserAssignment(UserRole role, UserAccount user)
        {
            return new UserAssignment(role, user);
        }
    }
}
