using Aritter.Domain.Seedwork.Validation.Rules;
using System;
using System.Collections;

namespace Aritter.Domain.Seedwork.Validation.Configuration
{
    public sealed class CollectionPropertyConfiguration<TEntity> : BasePropertyConfiguration<TEntity, ICollection>
        where TEntity : class, IValidatableEntity
    {
        public CollectionPropertyConfiguration(Feature<TEntity> feature, Func<TEntity, ICollection> provider)
            : base(feature, provider)
        {
        }

        public CollectionPropertyConfiguration<TEntity> IsRequired()
        {
            return IsRequired(null);
        }

        public CollectionPropertyConfiguration<TEntity> IsRequired(string invalidMessage)
        {
            Feature.AddRule(new RequiredRule<TEntity, ICollection>(Provider)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasMinCount(int minCount)
        {
            return HasMinCount(minCount, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasMinCount(int minCount, string invalidMessage)
        {
            Feature.AddRule(new MinCountRule<TEntity>(Provider, minCount)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasMaxCount(int maxCount)
        {
            return HasMaxCount(maxCount, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasMaxCount(int maxCount, string invalidMessage)
        {
            Feature.AddRule(new MaxCountRule<TEntity>(Provider, maxCount)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public CollectionPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public CollectionPropertyConfiguration<TEntity> HasCustom(Func<TEntity, bool> validateFunc, string invalidMessage)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }
    }
}
