using Aritter.Manager.Domain.Aggregates;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public class DictionaryValueMap : EntityMap<DictionaryValue>
	{
		public DictionaryValueMap()
		{
			this.Property(p => p.IdDictionary)
				.IsRequired();

			this.Property(p => p.Description)
				.IsMaxLength()
				.IsRequired();

			this.Property(p => p.Value)
				.IsRequired();

			this.HasRequired(p => p.Dictionary)
				.WithMany(p => p.DictionaryValues)
				.HasForeignKey(p => p.IdDictionary);
		}
	}
}
