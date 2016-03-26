using System;

namespace Aritter.Domain.Seedwork.Aggregates
{
	public abstract class Entity : IEntity
	{
		#region Constructor

		public Entity()
		{
			Guid = Guid.NewGuid();
		}

		#endregion

		#region Properties

		public int Id { get; set; }

		public Guid Guid { get; set; }

		#endregion Properties

		#region Methods

		public bool IsPersisted()
		{
			return Id > 0;
		}

		#endregion
	}
}