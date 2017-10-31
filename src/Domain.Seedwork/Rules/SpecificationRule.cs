using Ritter.Domain.Seedwork.Specs;
using System;

namespace Ritter.Domain.Seedwork.Rules
{
    public sealed class SpecificationRule<TEntity> : ValidationRule<TEntity>
        where TEntity : class
    {
        public ISpecification<TEntity> Rule { get; private set; }

        public SpecificationRule(ISpecification<TEntity> rule)
            : this(rule, null)
        {
        }

        public SpecificationRule(ISpecification<TEntity> rule, string message)
            : base(message)
        {
            Rule = rule ?? throw new ArgumentNullException(nameof(rule));
        }

        public override bool Validate(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Expected a valid non-null entity instance against which the rule can be evaluated.");

            return Rule.IsSatisfiedBy(entity);
        }
    }
}
