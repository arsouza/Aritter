namespace Aritter.Domain.SecurityModule.Aggregates.Permissions
{
    public static class AuthorizationFactory
    {
        public static Authorization CreateAuthorization(UserRole userRole, Permission permission)
        {
            return new Authorization(userRole, permission);
        }
    }
}
