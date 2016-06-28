using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Infra.Data.Seedwork.Extensions;
using Aritter.Infra.Data.Seedwork.Mapping;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class PermissionMap : EntityBuilder<Permission>
    {
        public override void Build(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(p => p.ResourceId)
                .HasUniqueIndex("UK_Permission", 1);

            Property(p => p.Rule)
                .HasUniqueIndex("UK_Permission", 3);

            HasRequired(p => p.Resource)
                .WithMany(p => p.Permissions)
                .HasForeignKey(p => p.ResourceId);
        }
    }
}
