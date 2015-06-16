namespace Aritter.Manager.Domain.Aggregates
{
	public class DictionaryValue : Entity
	{
		public int IdDictionary { get; set; }
		public int Value { get; set; }
		public string Description { get; set; }
		public virtual Dictionary Dictionary { get; set; }
	}
}
