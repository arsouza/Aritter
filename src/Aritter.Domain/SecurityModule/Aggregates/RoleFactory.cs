namespace Aritter.Domain.SecurityModule.Aggregates
{
    public static class RoleFactory
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

        public static RoleMember CreateAssignment(Role role, UserAccount member)
        {
            return new RoleMember(role, member);
        }
    }
}
