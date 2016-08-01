namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public static class AuthorizationFactory
    {
        public static Authorization CreateAuthorization(Permission permission, Role role)
        {
            return new Authorization(permission, role);
        }
    }
}
