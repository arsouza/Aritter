using Aritter.Domain.Aggregates;
using Aritter.Infrastructure.Data.Extensions;

namespace Aritter.Infrastructure.Data.Mapping
{
	public class OperationMap : EntityMap<Operation>
	{
		public OperationMap()
		{
			Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Operation")
				.IsRequired();

			Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();
		}
	}
}
