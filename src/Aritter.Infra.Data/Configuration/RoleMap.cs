using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
	internal sealed class RoleMap : EntityBuilder<Role>
	{
		public override void Build(EntityTypeBuilder<Role> builder)
		{
			builder.Property(p => p.Name)
				.HasMaxLength(50);

			builder.Property(p => p.Description)
				.HasMaxLength(255);

			builder
				.HasIndex(p => p.Name)
				.IsUnique();
		}
	}
}
