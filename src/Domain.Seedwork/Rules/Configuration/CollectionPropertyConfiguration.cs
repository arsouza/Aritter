using Ritter.Domain.Seedwork.Rules.Validation;
using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules.Configuration
{
    public sealed class CollectionPropertyConfiguration<TEntity> : BasePropertyConfiguration<TEntity, ICollection>
        where TEntity : class
    {
        public CollectionPropertyConfiguration(ValidationFeature<TEntity> feature, Expression<Func<TEntity, ICollection>> expression)
            : base(feature, expression)
        {
        }

        public CollectionPropertyConfiguration<TEntity> IsRequired()
        {
            return IsRequired(null);
        }

        public CollectionPropertyConfiguration<TEntity> IsRequired(string message)
        {
            Feature.AddRule(new RequiredRule<TEntity, ICollection>(Expression, message));
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasMinCount(int minCount)
        {
            return HasMinCount(minCount, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasMinCount(int minCount, string message)
        {
            Feature.AddRule(new MinCountRule<TEntity>(Expression, minCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasMaxCount(int maxCount)
        {
            return HasMaxCount(maxCount, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasMaxCount(int maxCount, string message)
        {
            Feature.AddRule(new MaxCountRule<TEntity>(Expression, maxCount, message));
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc, string message)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc, message));
            return this;
        }
    }
}
