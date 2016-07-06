using Aritter.Domain.Seedwork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    public interface IEntityBuilder<TEntity>
        where TEntity : class, IEntity
    {
        void Build(EntityTypeBuilder<TEntity> builder);
    }
}