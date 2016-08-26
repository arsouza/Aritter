namespace Aritter.Domain.SecurityModule.Aggregates
{
    public static class UserRoleFactory
    {
        public static UserRole CreateRole(string name, Client client)
        {
            return CreateRole(name, null, client);
        }

        public static UserRole CreateRole(string name, string description, Client client)
        {
            var userRole = new UserRole(name, description);
            userRole.SetClient(client);

            return userRole;
        }

        public static UserAssignment CreateUserAssignment(UserRole role, UserAccount user)
        {
            return new UserAssignment(role, user);
        }
    }
}
