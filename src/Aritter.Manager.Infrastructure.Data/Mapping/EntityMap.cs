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
			this.HasKey(p => p.Id);

			this.Property(p => p.Id)
				.IsRequired();

			this.Property(p => p.IsActive)
				.IsRequired();
		}

		#endregion Constructors
	}
}