using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Crosscutting.Validations.Rules;
using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Configurations
{
    public sealed class PrimitivePropertyConfiguration<TValidable, TProp> : BasePropertyConfiguration<TValidable, TProp>
        where TValidable : class
        where TProp : struct
    {
        public PrimitivePropertyConfiguration(
            ValidationContext context,
            Expression<Func<TValidable, TProp>> expression)
            : base(context, expression) { }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsRequired()
        {
            return IsRequired(null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsRequired(string message)
        {
            Context.AddRule(new RequiredRule<TValidable, TProp>(Expression, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasMinValue(TProp minValue)
        {
            return HasMinValue(minValue, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasMinValue(TProp minValue, string message)
        {
            Context.AddRule(new MinRule<TValidable, TProp>(Expression, minValue, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasMaxValue(TProp maxValue)
        {
            return HasMaxValue(maxValue, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasMaxValue(TProp maxValue, string message)
        {
            Context.AddRule(new MaxRule<TValidable, TProp>(Expression, maxValue, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsGreaterThan(TProp value)
        {
            return IsGreaterThan(value, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsGreaterThan(TProp value, string message)
        {
            Context.AddRule(new GreatherThanRule<TValidable, TProp>(Expression, value, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsGreaterThanOrEqualsTo(TProp value)
        {
            return IsGreaterThanOrEqualsTo(value, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsGreaterThanOrEqualsTo(TProp value, string message)
        {
            Context.AddRule(new GreatherThanOrEqualsToRule<TValidable, TProp>(Expression, value, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsLessThan(TProp value)
        {
            return IsLessThan(value, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsLessThan(TProp value, string message)
        {
            Context.AddRule(new LessThanRule<TValidable, TProp>(Expression, value, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsLessThanOrEqualsTo(TProp value)
        {
            return IsLessThanOrEqualsTo(value, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> IsLessThanOrEqualsTo(TProp value, string message)
        {
            Context.AddRule(new LessThanOrEqualsToRule<TValidable, TProp>(Expression, value, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasRange(TProp min, TProp max)
        {
            return HasRange(min, max, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasRange(TProp min, TProp max, string message)
        {
            Context.AddRule(new RangeRule<TValidable, TProp>(Expression, min, max, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasCustom(Func<TValidable, bool> validateFunc, string message)
        {
            Context.AddRule(new CustomRule<TValidable, TProp>(Expression, validateFunc, message));
            return this;
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public PrimitivePropertyConfiguration<TValidable, TProp> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Context.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}
