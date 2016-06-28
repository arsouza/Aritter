using Aritter.Domain.Seedwork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aritter.Infra.Data.Configuration
{
    public interface IEntityBuilder<TEntity> where TEntity : class
    {
        void Build(EntityTypeBuilder<TEntity> builder);
    }
}