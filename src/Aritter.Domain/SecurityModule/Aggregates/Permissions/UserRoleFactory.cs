using Aritter.Domain.SecurityModule.Aggregates.Modules;
using Aritter.Domain.SecurityModule.Aggregates.Users;

namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public static class UserRoleFactory
    {
        public static UserRole CreateRole(string name, Application application)
        {
            return CreateRole(name, null, application);
        }

        public static UserRole CreateRole(string name, string description, Application application)
        {
            var userRole = new UserRole(name, description);
            userRole.SetApplication(application);

            return userRole;
        }

        public static UserAssignment CreateUserAssignment(UserRole role, UserAccount user)
        {
            return new UserAssignment(role, user);
        }
    }
}
