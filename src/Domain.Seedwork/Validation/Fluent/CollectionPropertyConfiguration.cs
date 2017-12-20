using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Fluent
{
    public sealed class CollectionPropertyConfiguration<TValidable> : BasePropertyConfiguration<TValidable, ICollection> where TValidable : class, IValidable
    {
        public CollectionPropertyConfiguration(ValidationContract<TValidable> contract, Expression<Func<TValidable, ICollection>> expression) : base(contract, expression)
        {}

        public CollectionPropertyConfiguration<TValidable> IsRequired()
        {
            return IsRequired(null);
        }

        public CollectionPropertyConfiguration<TValidable> IsRequired(string message)
        {
            Contract.AddRule(new RequiredRule<TValidable, ICollection>(Expression, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable> HasMinCount(int minCount)
        {
            return HasMinCount(minCount, null);
        }

        public CollectionPropertyConfiguration<TValidable> HasMinCount(int minCount, string message)
        {
            Contract.AddRule(new MinCountRule<TValidable>(Expression, minCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable> HasMaxCount(int maxCount)
        {
            return HasMaxCount(maxCount, null);
        }

        public CollectionPropertyConfiguration<TValidable> HasMaxCount(int maxCount, string message)
        {
            Contract.AddRule(new MaxCountRule<TValidable>(Expression, maxCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable> HasCustom(Func<TValidable, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public CollectionPropertyConfiguration<TValidable> HasCustom(Func<TValidable, bool> validateFunc, string message)
        {
            Contract.AddRule(new CustomRule<TValidable>(validateFunc, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public CollectionPropertyConfiguration<TValidable> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Contract.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}