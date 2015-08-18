using Aritter.Domain.Aggregates;
using Aritter.Infra.Data.Extensions;

namespace Aritter.Infra.Data.Mapping
{
	public class ModuleMap : EntityMap<Module>
	{
		public ModuleMap()
		{
			Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Module");

			Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();
		}
	}
}
