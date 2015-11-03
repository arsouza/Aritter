using Aritter.Domain.Contracts;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
	public class Permission : Entity
	{
		public int ResourceId { get; set; }
		public int OperationId { get; set; }
		public virtual Operation Operation { get; set; }
		public virtual Resource Resource { get; set; }
		public virtual ICollection<Authorization> Authorizations { get; set; }
	}
}
