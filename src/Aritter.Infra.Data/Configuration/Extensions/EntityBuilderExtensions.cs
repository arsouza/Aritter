using Aritter.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;

namespace Aritter.Infra.Data.Configuration.Extensions
{
    internal static class EntityBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, IEntityBuilder<TEntity> entityBuilder)
            where TEntity : class, IEntity
        {
            modelBuilder.Entity<TEntity>(entityBuilder.Build);
        }
    }
}
