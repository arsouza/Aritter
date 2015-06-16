using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class ModuleMap : EntityMap<Module>
	{
		public ModuleMap()
		{
			this.Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Module")
				.IsRequired();

			this.Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();
		}
	}
}
