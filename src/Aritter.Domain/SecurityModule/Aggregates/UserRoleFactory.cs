namespace Aritter.Domain.SecurityModule.Aggregates
{
    public static class UserRoleFactory
    {
        public static Role CreateRole(string name, Client client)
        {
            return CreateRole(name, null, client);
        }

        public static Role CreateRole(string name, string description, Client client)
        {
            var userRole = new Role(name, description);
            userRole.SetClient(client);

            return userRole;
        }

        public static UserAssignment CreateUserAssignment(Role role, UserAccount account)
        {
            return new UserAssignment(role, account);
        }
    }
}
