using Aritter.Domain.SecurityModule.Aggregates.Modules;
using Aritter.Domain.SecurityModule.Aggregates.Users;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public static class RoleFactory
    {
        public static Role CreateRole(Application application, string name)
        {
            return new Role(application, name);
        }

        public static Role CreateRole(Application application, string name, string description)
        {
            return new Role(application, name, description);
        }

        public static UserAssignment CreateUserAssignment(Role role, User user)
        {
            return new UserAssignment(role, user);
        }
    }
}
