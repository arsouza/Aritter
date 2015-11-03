using Aritter.Domain.Contracts;
using System.Collections.Generic;

namespace Aritter.Domain.SecurityModule.Aggregates
{
	public class Module : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<ModuleRole> ModuleRoles { get; set; }
		public virtual ICollection<Resource> Resources { get; set; }
	}
}
