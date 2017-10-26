using Ritter.Domain.Seedwork.Specs;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules.Validation.Configuration
{
    public sealed class PrimitivePropertyConfiguration<TEntity, TProp> : BasePropertyConfiguration<TEntity, TProp>
        where TEntity : class
        where TProp : struct
    {
        public PrimitivePropertyConfiguration(ValidationFeature<TEntity> feature, Expression<Func<TEntity, TProp>> expression)
            : base(feature, expression)
        {
        }
        public PrimitivePropertyConfiguration<TEntity, TProp> IsRequired()
        {
            return IsRequired(null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> IsRequired(string message)
        {
            Feature.AddRule(new RequiredRule<TEntity, TProp>(Expression, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasMinValue(TProp minValue)
        {
            return HasMinValue(minValue, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasMinValue(TProp minValue, string message)
        {
            Feature.AddRule(new MinRule<TEntity, TProp>(Expression, minValue, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasMaxValue(TProp maxValue)
        {
            return HasMaxValue(maxValue, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasMaxValue(TProp maxValue, string message)
        {
            Feature.AddRule(new MaxRule<TEntity, TProp>(Expression, maxValue, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasRange(TProp min, TProp max)
        {
            return HasRange(min, max, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasRange(TProp min, TProp max, string message)
        {
            Feature.AddRule(new RangeRule<TEntity, TProp>(Expression, min, max, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasCustom(Func<TEntity, bool> validateFunc, string message)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasSpecification(ISpecification<TEntity> specification)
        {
            return HasSpecification(specification, null);
        }

        public PrimitivePropertyConfiguration<TEntity, TProp> HasSpecification(ISpecification<TEntity> specification, string message)
        {
            Feature.AddRule(new SpecificationRule<TEntity>(specification, message));
            return this;
        }
    }
}
