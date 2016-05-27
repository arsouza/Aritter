using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Infra.Data.Seedwork.Extensions;
using Aritter.Infra.Data.Seedwork.Mapping;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class PermissionMap : EntityMap<Permission>
    {
        public PermissionMap()
        {
            Property(p => p.ResourceId)
                .HasUniqueIndex("UK_Permission", 1);

            Property(p => p.Rule)
                .HasUniqueIndex("UK_Permission", 3);

            HasRequired(p => p.Resource)
                .WithMany(p => p.Permissions)
                .HasForeignKey(p => p.ResourceId);
        }
    }
}
