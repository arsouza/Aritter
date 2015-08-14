using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Extensions;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class ResourceMap : AuditableMap<Resource>
	{
		public ResourceMap()
		{
			Property(p => p.Action)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Resource", 6)
				.IsOptional();

			Property(p => p.Controller)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Resource", 5)
				.IsOptional();

			Property(p => p.Area)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Resource", 4)
				.IsOptional();

			Property(p => p.Title)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Resource", 3)
				.IsRequired();

			Property(p => p.Description)
				.HasMaxLength(100)
				.IsOptional();

			Property(p => p.Icon)
				.HasMaxLength(20)
				.IsOptional();

			Property(p => p.Order)
				.HasUniqueIndex("UQ_Resource", 7)
				.IsRequired();

			Property(p => p.ParentId)
				.HasUniqueIndex("UQ_Resource", 2)
				.IsOptional();

			Property(p => p.ModuleId)
				.HasUniqueIndex("UQ_Resource", 1)
				.IsRequired();

			HasRequired(p => p.Module)
				.WithMany(p => p.Resources)
				.HasForeignKey(p => p.ModuleId);

			HasOptional(p => p.Parent)
				.WithMany(p => p.Children)
				.HasForeignKey(p => p.ParentId);
		}
	}
}
