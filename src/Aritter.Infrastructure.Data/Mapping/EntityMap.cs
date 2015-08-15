using Aritter.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Aritter.Infrastructure.Data.Mapping
{
	public abstract class EntityMap<TEntity> : EntityTypeConfiguration<TEntity>
		where TEntity : class, IEntity
	{
		#region Constructors

		public EntityMap()
		{
			HasKey(p => p.Id);
		}

		#endregion Constructors
	}
}