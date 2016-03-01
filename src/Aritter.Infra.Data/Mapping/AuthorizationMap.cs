using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class AuthorizationMap : EntityMap<Authorization>
    {
        public AuthorizationMap()
        {
            Property(p => p.PermissionId)
                .HasUniqueIndex("UQ_RoleAuthorization", 1);

            Property(p => p.RoleId)
                .HasUniqueIndex("UQ_RoleAuthorization", 2);

            HasRequired(p => p.Permission)
                .WithMany(p => p.Authorizations)
                .HasForeignKey(p => p.PermissionId);

            HasRequired(p => p.Role)
                .WithMany(p => p.Authorizations)
                .HasForeignKey(p => p.RoleId);
        }
    }
}
