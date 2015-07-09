using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class DictionaryMap : EntityMap<Dictionary>
	{
		public DictionaryMap()
		{
			Property(p => p.Name)
				.HasMaxLength(255)
				.IsRequired();
		}
	}
}
