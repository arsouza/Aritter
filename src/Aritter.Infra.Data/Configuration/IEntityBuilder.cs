using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aritter.Infra.Data.Configuration
{
    public interface IEntityBuilder<TEntity> where TEntity : class
    {
        void Build(EntityTypeBuilder<TEntity> builder);
    }
}