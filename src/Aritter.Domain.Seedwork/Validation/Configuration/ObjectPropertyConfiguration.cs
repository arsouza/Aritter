using Aritter.Domain.Seedwork.Validation.Rules;
using System;

namespace Aritter.Domain.Seedwork.Validation.Configuration
{
    public class ObjectPropertyConfiguration<TEntity, TProperty> : BasePropertyConfiguration<TEntity, TProperty>
        where TProperty : class
        where TEntity : class, IValidatableEntity
    {
        public ObjectPropertyConfiguration(Feature<TEntity> feature, Func<TEntity, TProperty> provider) : base(feature, provider)
        {
        }

        public virtual ObjectPropertyConfiguration<TEntity, TProperty> IsRequired()
        {
            return IsRequired(null);
        }

        public virtual ObjectPropertyConfiguration<TEntity, TProperty> IsRequired(string invalidMessage)
        {
            Feature.AddRule(new RequiredRule<TEntity, TProperty>(Provider)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }

        public ObjectPropertyConfiguration<TEntity, TProperty> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public ObjectPropertyConfiguration<TEntity, TProperty> HasCustom(Func<TEntity, bool> validateFunc, string invalidMessage)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc)
            {
                InvalidMessage = invalidMessage
            });
            return this;
        }
    }
}
