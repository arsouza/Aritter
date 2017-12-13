using Ritter.Domain.Seedwork.Specifications;
using Ritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Configuration
{
    public sealed class CollectionPropertyConfiguration<TEntity> : BasePropertyConfiguration<TEntity, ICollection> where TEntity : class
    {
        public CollectionPropertyConfiguration(ValidationContext<TEntity> context, Expression<Func<TEntity, ICollection>> expression) : base(context, expression)
        {}

        public CollectionPropertyConfiguration<TEntity> IsRequired()
        {
            return IsRequired(null);
        }

        public CollectionPropertyConfiguration<TEntity> IsRequired(string message)
        {
            Context.AddRule(new RequiredRule<TEntity, ICollection>(Expression, message));
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasMinCount(int minCount)
        {
            return HasMinCount(minCount, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasMinCount(int minCount, string message)
        {
            Context.AddRule(new MinCountRule<TEntity>(Expression, minCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasMaxCount(int maxCount)
        {
            return HasMaxCount(maxCount, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasMaxCount(int maxCount, string message)
        {
            Context.AddRule(new MaxCountRule<TEntity>(Expression, maxCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc, string message)
        {
            Context.AddRule(new CustomRule<TEntity>(validateFunc, message));
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasSpecification(ISpecification<TEntity> specification)
        {
            return HasSpecification(specification, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasSpecification(ISpecification<TEntity> specification, string message)
        {
            Context.AddRule(new SpecificationRule<TEntity>(specification, message));
            return this;
        }
    }
}