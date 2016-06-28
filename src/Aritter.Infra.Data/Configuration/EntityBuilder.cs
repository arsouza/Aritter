using Aritter.Domain.Seedwork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    public abstract class EntityBuilder<TEntity> : IEntityBuilder<TEntity>
		where TEntity : class, IEntity
	{
		public virtual void Build(EntityTypeBuilder<TEntity> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Id)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(p => p.Identity)
				.IsRequired();
		}
	}
}
