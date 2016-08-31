namespace Aritter.Domain.SecurityModule.Aggregates
{
    public static class AuthorizationFactory
    {
        public static Authorization CreateAuthorization(Role role, Permission permission)
        {
            var authorization = new Authorization();
            authorization.SetPermission(permission);
            authorization.SetUserRole(role);

            return authorization;
        }
    }
}
