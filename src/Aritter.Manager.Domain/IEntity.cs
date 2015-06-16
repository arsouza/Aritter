namespace Aritter.Manager.Domain
{
	public interface IEntity
	{
		#region Properties

		int Id { get; set; }

		bool IsActive { get; set; }

		#endregion Properties
	}
}