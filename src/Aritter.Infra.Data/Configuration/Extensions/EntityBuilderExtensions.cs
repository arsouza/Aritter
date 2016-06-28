using Aritter.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
