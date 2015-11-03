using Aritter.Domain.SecurityModule.Aggregates;
using Aritter.Infra.Data.Extensions;

namespace Aritter.Infra.Data.Mapping
{
	internal sealed class OperationMap : EntityMap<Operation>
	{
		public OperationMap()
		{
			Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Operation");

			Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();
		}
	}
}
