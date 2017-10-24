using Ritter.Domain.Seedwork.Rules.Validation;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules.Configuration
{
    public abstract class BasePropertyConfiguration<TEntity, TProp>
        where TEntity : class
    {
        public BasePropertyConfiguration(ValidationFeature<TEntity> feature, Expression<Func<TEntity, TProp>> expression)
        {
            Feature = feature ?? throw new ArgumentNullException(nameof(feature));
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }

        public ValidationFeature<TEntity> Feature { get; protected set; }

        public Expression<Func<TEntity, TProp>> Expression { get; protected set; }
    }
}
