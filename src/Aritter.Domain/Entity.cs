namespace Aritter.Domain
{
	/// <summary>
	///     Base class for entities
	/// </summary>
	public abstract class Entity : IEntity
	{
		#region Constructor

		public Entity()
		{
			IsActive = true;
		}

		#endregion

		#region Properties

		public int Id { get; set; }

		public bool IsActive { get; set; }

		#endregion Properties
	}
}