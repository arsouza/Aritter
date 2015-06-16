using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class ResourceMap : EntityMap<Resource>
	{
		public ResourceMap()
		{
			this.Property(p => p.Action)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Resource", 6)
				.IsOptional();

			this.Property(p => p.Controller)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Resource", 5)
				.IsOptional();

			this.Property(p => p.Area)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Resource", 4)
				.IsOptional();

			this.Property(p => p.Title)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Resource", 3)
				.IsRequired();

			this.Property(p => p.Description)
				.HasMaxLength(100)
				.IsOptional();

			this.Property(p => p.Icon)
				.HasMaxLength(20)
				.IsOptional();

			this.Property(p => p.Order)
				.HasUniqueIndex("UQ_Resource", 7)
				.IsRequired();

			this.Property(p => p.ParentId)
				.HasUniqueIndex("UQ_Resource", 2)
				.IsOptional();

			this.Property(p => p.ModuleId)
				.HasUniqueIndex("UQ_Resource", 1)
				.IsRequired();

			this.HasRequired(p => p.Module)
				.WithMany(p => p.Resources)
				.HasForeignKey(p => p.ModuleId);

			this.HasOptional(p => p.Parent)
				.WithMany(p => p.Children)
				.HasForeignKey(p => p.ParentId);
		}
	}
}
