using Aritter.Domain.Seedwork.Specs;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Rules.Validation.Common
{
    public sealed class HasRequiredRule<TEntity> : ValidationRule<TEntity>
         where TEntity : class, IEntity
    {
        public HasRequiredRule(Expression<Func<TEntity, object>> expression, string message)
            : base(new HasRequiredSpec<TEntity>(expression), message)
        {
        }

        public HasRequiredRule(Expression<Func<TEntity, object>> expression, string message, string property)
            : base(new HasRequiredSpec<TEntity>(expression), message, property)
        {
        }
    }
}
