using Aritter.Manager.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Aritter.Manager.Infrastructure.Data.Mapping
{
	public abstract class EntityMap<TEntity> : EntityTypeConfiguration<TEntity>
		where TEntity : class, IEntity
	{
		#region Constructors

		public EntityMap()
		{
			HasKey(p => p.Id);

			Property(p => p.Id)
				.IsRequired();

			Property(p => p.IsActive)
				.IsRequired();
		}

		#endregion Constructors
	}
}