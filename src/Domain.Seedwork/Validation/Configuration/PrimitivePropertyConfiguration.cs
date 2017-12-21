using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public sealed class PrimitivePropertyConfiguration<TValidable, TProp> : BasePropertyConfiguration<TValidable, TProp> where TValidable : class, IValidable where TProp : struct
    {
        public PrimitivePropertyConfiguration(ValidationContract<TValidable> contract, Expression<Func<TValidable, TProp>> expression) : base(contract, expression) { }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsRequired()
        {
            return IsRequired(null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsRequired(string message)
        {
            Contract.AddRule(new RequiredRule<TValidable, TProp>(Expression, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasMinValue(TProp minValue)
        {
            return HasMinValue(minValue, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasMinValue(TProp minValue, string message)
        {
            Contract.AddRule(new MinRule<TValidable, TProp>(Expression, minValue, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasMaxValue(TProp maxValue)
        {
            return HasMaxValue(maxValue, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasMaxValue(TProp maxValue, string message)
        {
            Contract.AddRule(new MaxRule<TValidable, TProp>(Expression, maxValue, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasRange(TProp min, TProp max)
        {
            return HasRange(min, max, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasRange(TProp min, TProp max, string message)
        {
            Contract.AddRule(new RangeRule<TValidable, TProp>(Expression, min, max, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc, string message)
        {
            Contract.AddRule(new CustomRule<TValidable>(validateFunc, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Contract.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}