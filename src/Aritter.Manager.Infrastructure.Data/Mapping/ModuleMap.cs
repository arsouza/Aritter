using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
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
