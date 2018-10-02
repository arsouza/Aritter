using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Crosscutting.Validations.Rules;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Configurations
{
    public sealed class CollectionPropertyConfiguration<TValidable> : BasePropertyConfiguration<TValidable, ICollection>
        where TValidable : class
    {
        public CollectionPropertyConfiguration(
            ValidationContext context,
            Expression<Func<TValidable, ICollection>> expression)
            : base(context, expression) { }

        public CollectionPropertyConfiguration<TValidable> IsRequired()
        {
            return IsRequired(null);
        }

        public CollectionPropertyConfiguration<TValidable> IsRequired(string message)
        {
            Context.AddRule(new RequiredRule<TValidable, ICollection>(Expression, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable> HasMinCount(int minCount)
        {
            return HasMinCount(minCount, null);
        }

        public CollectionPropertyConfiguration<TValidable> HasMinCount(int minCount, string message)
        {
            Context.AddRule(new MinCountRule<TValidable>(Expression, minCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable> HasMaxCount(int maxCount)
        {
            return HasMaxCount(maxCount, null);
        }

        public CollectionPropertyConfiguration<TValidable> HasMaxCount(int maxCount, string message)
        {
            Context.AddRule(new MaxCountRule<TValidable>(Expression, maxCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable> HasCustom(Func<TValidable, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public CollectionPropertyConfiguration<TValidable> HasCustom(Func<TValidable, bool> validateFunc, string message)
        {
            Context.AddRule(new CustomRule<TValidable>(validateFunc, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public CollectionPropertyConfiguration<TValidable> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Context.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}
