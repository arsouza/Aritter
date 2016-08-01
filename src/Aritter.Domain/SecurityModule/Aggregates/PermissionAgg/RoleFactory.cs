using Aritter.Domain.SecurityModule.Aggregates.UserAgg;

namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public static class RoleFactory
    {
        public static Role CreateRole(string name)
        {
            return new Role(name);
        }

        public static Role CreateRole(string name, string description)
        {
            return new Role(name, description);
        }

        public static UserAssignment CreateUserAssignment(Role role, User user)
        {
            return new UserAssignment(role, user);
        }
    }
}
