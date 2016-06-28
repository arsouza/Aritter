using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Infra.Data.Seedwork.Extensions;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class AuthorizationMap : EntityBuilder<Authorization>
    {
        public Authorization>()
        {
            Property(p => p.Id)
                .HasUniqueIndex("UK_RoleAuthorization", 1);

            Property(p => p.RoleId)
                .HasUniqueIndex("UK_RoleAuthorization", 2);

            HasRequired(p => p.Permission)
                .WithRequiredDependent(p => p.Authorization);

            HasRequired(p => p.Role)
                .WithMany(p => p.Authorizations)
                .HasForeignKey(p => p.RoleId);
        }
    }
}
