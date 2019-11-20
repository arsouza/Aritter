using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Crosscutting.Validations.Rules;
using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Configurations
{
    public sealed class PrimitiveNullablePropertyConfiguration<TValidable, TProp> : BasePropertyConfiguration<TValidable, TProp?>
        where TValidable : class
        where TProp : struct
    {
        public PrimitiveNullablePropertyConfiguration(
            ValidationContext context,
            Expression<Func<TValidable, TProp?>> expression)
            : base(context, expression)
        {
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsRequired()
        {
            return IsRequired(null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsRequired(string message)
        {
            Context.AddRule(new RequiredRule<TValidable, TProp?>(Expression, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasMinValue(TProp minValue)
        {
            return HasMinValue(minValue, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasMinValue(TProp minValue, string message)
        {
            Context.AddRule(new MinRule<TValidable, TProp?>(Expression, minValue, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasMaxValue(TProp maxValue)
        {
            return HasMaxValue(maxValue, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasMaxValue(TProp maxValue, string message)
        {
            Context.AddRule(new MaxRule<TValidable, TProp?>(Expression, maxValue, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsGreaterThan(TProp value)
        {
            return IsGreaterThan(value, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsGreaterThan(TProp value, string message)
        {
            Context.AddRule(new GreatherThanRule<TValidable, TProp?>(Expression, value, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsGreaterThanOrEqualsTo(TProp value)
        {
            return IsGreaterThanOrEqualsTo(value, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsGreaterThanOrEqualsTo(TProp value, string message)
        {
            Context.AddRule(new GreatherThanOrEqualsToRule<TValidable, TProp?>(Expression, value, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsLessThan(TProp value)
        {
            return IsLessThan(value, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsLessThan(TProp value, string message)
        {
            Context.AddRule(new LessThanRule<TValidable, TProp?>(Expression, value, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsLessThanOrEqualsTo(TProp value)
        {
            return IsLessThanOrEqualsTo(value, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> IsLessThanOrEqualsTo(TProp value, string message)
        {
            Context.AddRule(new LessThanOrEqualsToRule<TValidable, TProp?>(Expression, value, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasRange(TProp min, TProp max)
        {
            return HasRange(min, max, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasRange(TProp min, TProp max, string message)
        {
            Context.AddRule(new RangeRule<TValidable, TProp?>(Expression, min, max, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc, string message)
        {
            Context.AddRule(new CustomRule<TValidable, TProp?>(Expression, validateFunc, message));
            return this;
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public PrimitiveNullablePropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Context.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}
