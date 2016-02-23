﻿using Aritter.Domain.Seedwork.Aggregates;
using System.Data.Entity.ModelConfiguration;

namespace Aritter.Infra.Data.Mapping
{
    internal abstract class EntityMap<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        #region Constructors

        public EntityMap()
        {
            HasKey(p => p.Id);
        }

        #endregion Constructors
    }
}