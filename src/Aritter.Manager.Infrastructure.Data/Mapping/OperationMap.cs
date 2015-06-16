using Aritter.Manager.Domain.Aggregates;
using Aritter.Manager.Infrastructure.Data.Extensions;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class OperationMap : EntityMap<Operation>
	{
		public OperationMap()
		{
			this.Property(p => p.Name)
				.HasMaxLength(50)
				.HasUniqueIndex("UQ_Operation")
				.IsRequired();

			this.Property(p => p.Description)
				.HasMaxLength(255)
				.IsOptional();
		}
	}
}
