using Aritter.Domain.Seedwork.Aggregates;
using System.Collections.Generic;

namespace Aritter.Domain.Aggregates.Security
{
	public class Operation : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Permission> Permissions { get; set; }
	}
}
