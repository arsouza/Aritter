using Aritter.Domain.Seedwork.Specifications;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Rules.Validation.Common
{
    public sealed class RequiredPropertyRule<TEntity> : ValidationRule<TEntity>
         where TEntity : class, IEntity
    {
        public RequiredPropertyRule(Expression<Func<TEntity, object>> expression, string message)
            : base(new RequiredPropertySpec<TEntity>(expression), message)
        {
        }

        public RequiredPropertyRule(Expression<Func<TEntity, object>> expression, string message, string property)
            : base(new RequiredPropertySpec<TEntity>(expression), message, property)
        {
        }
    }
}
