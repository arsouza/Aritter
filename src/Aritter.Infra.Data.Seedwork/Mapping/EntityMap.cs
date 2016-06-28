﻿using Aritter.Domain.Seedwork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;

namespace Aritter.Infra.Data.Seedwork.Mapping
{
    public abstract class EntityBuilder<TEntity>
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