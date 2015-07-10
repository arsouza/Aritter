using System.Collections.Generic;

namespace Aritter.Manager.Domain.Aggregates
{
	public class Dictionary : Entity
	{
		public string Name { get; set; }
		public virtual ICollection<DictionaryValue> DictionaryValues { get; set; }
	}
}
