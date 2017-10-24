using Ritter.Domain.Seedwork.Specs;
using System;

namespace Ritter.Domain.Seedwork.Rules
{
    public abstract class SpecificationRule<TEntity> : ValidationRule<TEntity>
        where TEntity : class
    {
        public ISpecification<TEntity> Rule { get; protected set; }

        public SpecificationRule(ISpecification<TEntity> rule)
            : this(rule, null)
        {
        }

        public SpecificationRule(ISpecification<TEntity> rule, string message)
            : base(message)
        {
            Rule = rule ?? throw new ArgumentNullException(nameof(rule));
        }

        public bool IsSatisfied(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException("Expected a valid non-null entity instance against which the rule can be evaluated.");

            return Rule.IsSatisfiedBy(entity);
        }
    }
}
