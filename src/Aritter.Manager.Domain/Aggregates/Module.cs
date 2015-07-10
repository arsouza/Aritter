using System.Collections.Generic;

namespace Aritter.Manager.Domain.Aggregates
{
	public class Module : Auditable
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<ModuleRole> ModuleRoles { get; set; }
		public virtual ICollection<Resource> Resources { get; set; }
	}
}
