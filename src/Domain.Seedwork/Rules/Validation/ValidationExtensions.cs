using Ritter.Domain.Seedwork.Rules.Configuration;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public static class ValidationExtensions
    {
        public static ValidationFeature<TEntity> Feature<TEntity>(this ValidationFeatureSet<TEntity> featureSet, string name, Action<ValidationFeature<TEntity>> configAction)
            where TEntity : class
        {
            if (featureSet == null)
                throw new ArgumentNullException(nameof(featureSet));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            ValidationFeature<TEntity> feature;

            if (!featureSet.Features.ContainsKey(name))
                featureSet.Features.Add(name, new ValidationFeature<TEntity>(name));

            feature = featureSet.Features[name];
            configAction?.Invoke(feature);

            return feature;
        }

        public static ObjectPropertyConfiguration<TEntity, TProp> Property<TEntity, TProp>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, TProp>> expression)
            where TEntity : class
            where TProp : class
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return new ObjectPropertyConfiguration<TEntity, TProp>(feature, expression);
        }

        public static CollectionPropertyConfiguration<TEntity> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, ICollection>> expression)
            where TEntity : class
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return new CollectionPropertyConfiguration<TEntity>(feature, expression);
        }

        public static StringPropertyConfiguration<TEntity> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, string>> expression)
            where TEntity : class
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return new StringPropertyConfiguration<TEntity>(feature, expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, short> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, short>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, int> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, int>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, long> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, long>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, ushort> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, ushort>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, uint> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, uint>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, ulong> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, ulong>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, byte> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, byte>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, sbyte> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, sbyte>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, float> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, float>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, decimal> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, decimal>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, double> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, double>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        public static PrimitivePropertyConfiguration<TEntity, DateTime> Property<TEntity>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, DateTime>> expression)
            where TEntity : class
        {
            return feature.PropertyInner(expression);
        }

        private static PrimitivePropertyConfiguration<TEntity, TProp> PropertyInner<TEntity, TProp>(this ValidationFeature<TEntity> feature, Expression<Func<TEntity, TProp>> expression)
            where TEntity : class
            where TProp : struct
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return new PrimitivePropertyConfiguration<TEntity, TProp>(feature, expression);
        }
    }
}