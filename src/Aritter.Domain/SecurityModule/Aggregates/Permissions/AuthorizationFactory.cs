namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public static class AuthorizationFactory
    {
        public static Authorization CreateAuthorization(UserRole userRole, Permission permission)
        {
            var authorization = new Authorization();
            authorization.SetPermission(permission);
            authorization.SetUserRole(userRole);

            return authorization;
        }
    }
}
