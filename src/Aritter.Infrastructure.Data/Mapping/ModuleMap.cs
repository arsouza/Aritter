using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Extensions;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class ModuleMap : EntityMap<Module>
	{
		public ModuleMap()
		{
			Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Module")
				.IsRequired();

			Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();
		}
	}
}
