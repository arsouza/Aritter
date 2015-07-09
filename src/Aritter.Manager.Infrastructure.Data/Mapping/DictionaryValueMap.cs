using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class DictionaryValueMap : EntityMap<DictionaryValue>
	{
		public DictionaryValueMap()
		{
			Property(p => p.IdDictionary)
				.IsRequired();

			Property(p => p.Description)
				.IsMaxLength()
				.IsRequired();

			Property(p => p.Value)
				.IsRequired();

			HasRequired(p => p.Dictionary)
				.WithMany(p => p.DictionaryValues)
				.HasForeignKey(p => p.IdDictionary);
		}
	}
}
