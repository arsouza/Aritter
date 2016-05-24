using Aritter.Domain.Seedwork.Validation.Rules;
using System;

namespace Aritter.Domain.Seedwork.Validation.Configuration
{
    public sealed class PrimitivePropertyConfiguration<TEntity, TProperty> : BasePropertyConfiguration<TEntity, TProperty>
        where TProperty : struct
        where TEntity : class, IValidatableEntity
    {
        public PrimitivePropertyConfiguration(Feature<TEntity> feature, Func<TEntity, TProperty> provider)
            : base(feature, provider)
        {
        }

        public PrimitivePropertyConfiguration<TEntity, TProperty> HasMinValue(TProperty minValue)
        {
            return HasMinValue(minValue, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProperty> HasMinValue(TProperty minValue, string invalidMessage)
        {
            Feature.AddRule(new MinRule<TEntity, TProperty>(Provider, minValue)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public PrimitivePropertyConfiguration<TEntity, TProperty> HasMaxValue(TProperty maxValue)
        {
            return HasMaxValue(maxValue, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProperty> HasMaxValue(TProperty maxValue, string invalidMessage)
        {
            Feature.AddRule(new MaxRule<TEntity, TProperty>(Provider, maxValue)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public PrimitivePropertyConfiguration<TEntity, TProperty> HasRange(TProperty min, TProperty max)
        {
            return HasRange(min, max, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProperty> HasRange(TProperty min, TProperty max, string invalidMessage)
        {
            Feature.AddRule(new RangeRule<TEntity, TProperty>(Provider, min, max)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public PrimitivePropertyConfiguration<TEntity, TProperty> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProperty> HasCustom(Func<TEntity, bool> validateFunc, string invalidMessage)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }
    }
}
