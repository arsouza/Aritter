using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
	internal sealed class PermissionMap : EntityBuilder<Permission>
	{
		public override void Build(EntityTypeBuilder<Permission> builder)
		{
			base.Build(builder);

			builder.HasOne(p => p.Resource)
				.WithMany(p => p.Permissions)
				.HasForeignKey(p => p.ResourceId);

			builder
				.HasIndex(p => new { p.ResourceId, p.Rule })
				.IsUnique();
		}
	}
}
