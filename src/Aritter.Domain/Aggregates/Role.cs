using System.Collections.Generic;

namespace Aritter.Domain.Aggregates
{
	public class Role : Auditable
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int PrecedenceOrder { get; set; }
		public virtual UserPolicy UserPolicy { get; set; }
		public virtual ICollection<ModuleRole> ModuleRoles { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; }
		public virtual ICollection<Authorization> Authorizations { get; set; }
	}
}
