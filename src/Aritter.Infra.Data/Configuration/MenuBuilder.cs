using Aritter.Domain.SecurityModule.Aggregates.ModuleAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
	internal sealed class MenuBuilder : EntityBuilder<Menu>
	{
		public override void Build(EntityTypeBuilder<Menu> builder)
		{
			base.Build(builder);

			builder.Property(p => p.Name)
				.HasMaxLength(50)
				.IsRequired();

			builder.Property(p => p.Description)
				.HasMaxLength(100);

			builder.Property(p => p.Image)
				.HasMaxLength(200);

			builder.Property(p => p.Url)
				.HasMaxLength(100);

			builder
				.HasOne(p => p.Module)
				.WithMany(p => p.Menus)
				.HasForeignKey(p => p.ModuleId);

			builder
				.HasOne(p => p.Parent)
				.WithMany(p => p.Children)
				.HasForeignKey(p => p.ParentId);

			builder
				.HasIndex(p => new { p.ParentId, p.ModuleId })
				.IsUnique();
		}
	}
}
