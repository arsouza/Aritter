using Aritter.Domain.Contracts;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
	public class Role : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual UserPolicy UserPolicy { get; set; }
		public virtual ICollection<ModuleRole> ModuleRoles { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; }
		public virtual ICollection<Authorization> Authorizations { get; set; }
	}
}
