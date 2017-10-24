using Ritter.Domain.Seedwork.Rules.Validation;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules.Configuration
{
    public class ObjectPropertyConfiguration<TEntity, TProp> : BasePropertyConfiguration<TEntity, TProp>
        where TEntity : class
        where TProp : class
    {
        public ObjectPropertyConfiguration(ValidationFeature<TEntity> feature, Expression<Func<TEntity, TProp>> expression)
            : base(feature, expression)
        {
        }

        public virtual ObjectPropertyConfiguration<TEntity, TProp> IsRequired()
        {
            return IsRequired(null);
        }

        public virtual ObjectPropertyConfiguration<TEntity, TProp> IsRequired(string message)
        {
            Feature.AddRule(new RequiredRule<TEntity, TProp>(Expression, message));
            return this;
        }

        public ObjectPropertyConfiguration<TEntity, TProp> HasCustom(Func<TEntity, bool> validateFunc)
        {
            return HasCustom(validateFunc, null);
        }

        public ObjectPropertyConfiguration<TEntity, TProp> HasCustom(Func<TEntity, bool> validateFunc, string message)
        {
            Feature.AddRule(new CustomRule<TEntity>(validateFunc, message));
            return this;
        }
    }
}
