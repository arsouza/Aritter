using Aritter.Domain.Seedwork.Aggregates;
using System.Data.Entity.ModelConfiguration;

namespace Aritter.Infra.Data.Seedwork.Mapping
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

            Property(p => p.Guid)
                .IsRequired();
        }

        #endregion Constructors
    }
}