using Aritter.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;

namespace Aritter.Infra.Data.Configuration.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, IEntityBuilder<TEntity> typeBuilder)
            where TEntity : class, IEntity
        {
            modelBuilder.Entity<TEntity>(typeBuilder.Build);
        }
    }
}
