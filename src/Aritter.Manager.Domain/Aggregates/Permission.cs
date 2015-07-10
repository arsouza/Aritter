using System.Collections.Generic;

namespace Aritter.Manager.Domain.Aggregates
{
	public class Permission : Auditable
	{
		public int ResourceId { get; set; }
		public int OperationId { get; set; }
		public virtual Operation Operation { get; set; }
		public virtual Resource Resource { get; set; }
		public virtual ICollection<Authorization> Authorizations { get; set; }
	}
}
