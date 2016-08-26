using Aritter.Domain.SecurityModule.Aggregates;

namespace Aritter.Domain.SecurityModule.Aggregates
{
    public static class PermissionFactory
    {
        public static Permission CreatePermission(Resource resource, Operation operation)
        {
            var permission = new Permission();
            permission.SetResource(resource);
            permission.SetOperation(operation);

            return permission;
        }
    }
}
