using Aritter.Domain.Seedwork.Validation.Configuration;
using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation
{

    public abstract class ValidatableEntity : Entity, IValidatableEntity
    {
        #region Fields

        private readonly object thisLock = new object();

        #endregion

        #region IValidatableEntity Members

        public Dictionary<string, Feature<IValidatableEntity>> Features { get; private set; }

        public Feature<IValidatableEntity> Configuration { get; private set; }

        public void ConfigureFeatures()
        {
            if (ShouldConfigure())
            {
                OnAddFeatures();
                OnConfigure();
            }
        }

        #endregion

        #region Protected Members

        protected virtual void OnConfigureFeature(Feature<IValidatableEntity> feature)
        {
        }

        protected virtual void OnAddFeatures()
        {
        }

        protected ObjectPropertyConfiguration<IValidatableEntity, TProp> Property<TProp>(Expression<Func<IValidatableEntity, TProp>> expression)
            where TProp : class
        {
            CheckConfigurationState();

            ThrowHelper.ThrowArgumentNullException(expression, nameof(expression));
            return new ObjectPropertyConfiguration<IValidatableEntity, TProp>(Configuration, expression.Compile());
        }

        protected CollectionPropertyConfiguration<IValidatableEntity> Property(Expression<Func<IValidatableEntity, ICollection>> expression)
        {
            CheckConfigurationState();

            ThrowHelper.ThrowArgumentNullException(expression, nameof(expression));
            return new CollectionPropertyConfiguration<IValidatableEntity>(Configuration, expression.Compile());
        }

        protected StringPropertyConfiguration<IValidatableEntity> Property(Expression<Func<IValidatableEntity, string>> expression)
        {
            CheckConfigurationState();

            ThrowHelper.ThrowArgumentNullException(expression, nameof(expression));
            return new StringPropertyConfiguration<IValidatableEntity>(Configuration, expression.Compile());
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, short> Property(Expression<Func<IValidatableEntity, short>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, int> Property(Expression<Func<IValidatableEntity, int>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, long> Property(Expression<Func<IValidatableEntity, long>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, ushort> Property(Expression<Func<IValidatableEntity, ushort>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, uint> Property(Expression<Func<IValidatableEntity, uint>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, ulong> Property(Expression<Func<IValidatableEntity, ulong>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, byte> Property(Expression<Func<IValidatableEntity, byte>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, sbyte> Property(Expression<Func<IValidatableEntity, sbyte>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, float> Property(Expression<Func<IValidatableEntity, float>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, decimal> Property(Expression<Func<IValidatableEntity, decimal>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, double> Property(Expression<Func<IValidatableEntity, double>> expression)
        {
            return PropertyInner(expression);
        }

        protected PrimitivePropertyConfiguration<IValidatableEntity, DateTime> Property(Expression<Func<IValidatableEntity, DateTime>> expression)
        {
            return PropertyInner(expression);
        }

        #endregion

        #region Private Members

        private PrimitivePropertyConfiguration<IValidatableEntity, TProp> PropertyInner<TProp>(Expression<Func<IValidatableEntity, TProp>> expression)
            where TProp : struct
        {
            CheckConfigurationState();

            ThrowHelper.ThrowArgumentNullException(expression, nameof(expression));
            return new PrimitivePropertyConfiguration<IValidatableEntity, TProp>(Configuration, expression.Compile());
        }

        private bool ShouldConfigure()
        {
            if (Features == null)
            {
                IDictionary cache;
                Type key = GetType();

                if (FeatureCache.TryGetCache(key, out cache))
                {
                    Features = cache as Dictionary<string, Feature<IValidatableEntity>>;
                    return cache.Count == 0;
                }
                else
                {
                    Features = new Dictionary<string, Feature<IValidatableEntity>>();
                    FeatureCache.AddCache(key, Features);
                    return true;
                }
            }
            return false;
        }

        private void OnConfigure()
        {
            lock (thisLock)
            {
                foreach (Feature<IValidatableEntity> feature in Features.Values)
                {
                    Configuration = feature;
                    OnConfigureFeature(feature);
                }
                Configuration = null;
            }
        }

        private void CheckConfigurationState()
        {
            ThrowHelper.ThrowInvalidOperationException(Configuration == null, "Configuration methods should only be called during the OnConfigureFeature call");
        }

        #endregion
    }
}
