using Aritter.Domain.Seedwork.Aggregates;

namespace Aritter.Domain.Security.Aggregates
{
	public class ModuleRole : Entity
	{
		public int ModuleId { get; set; }
		public int RoleId { get; set; }
		public virtual Module Module { get; set; }
		public virtual Role Role { get; set; }
	}
}