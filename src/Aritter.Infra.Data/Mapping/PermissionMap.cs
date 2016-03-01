using Aritter.Domain.Security.Aggregates;
using Aritter.Infra.Data.Seedwork.Mapping;
using Aritter.Infra.Data.SeedWork.Extensions;

namespace Aritter.Infra.Data.Mapping
{
    internal sealed class PermissionMap : EntityMap<Permission>
    {
        public PermissionMap()
        {
            Property(p => p.FeatureId)
                .HasUniqueIndex("UQ_Permission", 1);

            Property(p => p.Rule)
                .HasUniqueIndex("UQ_Permission", 2);

            HasRequired(p => p.Feature)
                .WithMany(p => p.Permissions)
                .HasForeignKey(p => p.FeatureId);
        }
    }
}
