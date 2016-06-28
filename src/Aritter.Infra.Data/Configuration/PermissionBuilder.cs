using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    internal sealed class PermissionBuilder : EntityBuilder<Permission>
	{
		public override void Build(EntityTypeBuilder<Permission> builder)
		{
			base.Build(builder);

			builder.HasOne(p => p.Resource)
				.WithMany(p => p.Permissions)
				.HasForeignKey(p => p.ResourceId);

            builder
                .HasOne(p => p.Authorization)
                .WithOne(p => p.Permission)
                .HasForeignKey<Authorization>(b => b.Id);

            builder
				.HasIndex(p => new { p.ResourceId, p.Rule })
				.IsUnique();
		}
	}
}
