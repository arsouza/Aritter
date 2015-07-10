namespace Aritter.Manager.Domain.Aggregates
{
	public class ModuleRole : Auditable
	{
		public int ModuleId { get; set; }
		public int RoleId { get; set; }
		public virtual Module Module { get; set; }
		public virtual Role Role { get; set; }
	}
}