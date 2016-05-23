using Aritter.Domain.Seedwork;
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

            Property(p => p.Identity)
                .IsRequired();
        }

        #endregion Constructors
    }
}