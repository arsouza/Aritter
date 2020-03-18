using Ritter.Infra.Crosscutting.Specifications;
using Ritter.Infra.Crosscutting.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Configurations
{
    public sealed class CollectionPropertyConfiguration<TValidable, TEnumerable> : BasePropertyConfiguration<TValidable, ICollection<TEnumerable>>
        where TValidable : class
    {
        public CollectionPropertyConfiguration(
            ValidationContext context,
            Expression<Func<TValidable, ICollection<TEnumerable>>> expression)
            : base(context, expression) { }

        public CollectionPropertyConfiguration<TValidable, TEnumerable> IsRequired()
        {
            return IsRequired(null);
        }

        public CollectionPropertyConfiguration<TValidable, TEnumerable> IsRequired(string message)
        {
            Context.AddRule(new RequiredRule<TValidable, ICollection<TEnumerable>>(Expression, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable, TEnumerable> HasMinCount(int minCount)
        {
            return HasMinCount(minCount, null);
        }

        public CollectionPropertyConfiguration<TValidable, TEnumerable> HasMinCount(int minCount, string message)
        {
            Context.AddRule(new MinCountRule<TValidable, TEnumerable>(Expression, minCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable, TEnumerable> HasMaxCount(int maxCount)
        {
            return HasMaxCount(maxCount, null);
        }

        public CollectionPropertyConfiguration<TValidable, TEnumerable> HasMaxCount(int maxCount, string message)
        {
            Context.AddRule(new MaxCountRule<TValidable, TEnumerable>(Expression, maxCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TValidable, TEnumerable> HasSpecification(ISpecification<TValidable> specification)
        {
            return HasSpecification(specification, null);
        }

        public CollectionPropertyConfiguration<TValidable, TEnumerable> HasSpecification(ISpecification<TValidable> specification, string message)
        {
            Context.AddRule(new SpecificationRule<TValidable>(specification, message));
            return this;
        }
    }
}
