namespace Aritter.Domain.SecurityModule.Aggregates.PermissionAgg
{
    public static class AuthorizationFactory
    {
        public static Authorization CreateAuthorization(Role role, Permission permission)
        {
            return new Authorization(role, permission);
        }
    }
}
