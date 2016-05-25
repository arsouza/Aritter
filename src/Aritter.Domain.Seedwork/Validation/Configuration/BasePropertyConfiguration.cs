using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Validation.Configuration
{
    public abstract class BasePropertyConfiguration<TEntity, TProperty>
        where TEntity : class, IValidatableEntity
    {
        public BasePropertyConfiguration(Feature<TEntity> feature, Func<TEntity, TProperty> provider)
        {
            ThrowHelper.ThrowArgumentNullException(feature, nameof(feature));
            ThrowHelper.ThrowArgumentNullException(provider, nameof(provider));

            Feature = feature;
            Provider = provider;
        }

        public Feature<TEntity> Feature { get; protected set; }

        public Func<TEntity, TProperty> Provider { get; protected set; }
    }
}
