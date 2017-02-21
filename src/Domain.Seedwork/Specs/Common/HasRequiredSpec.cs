using Aritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Aritter.Domain.Seedwork.Specs
{
    public sealed class HasRequiredSpec<TEntity> : Specification<TEntity>
          where TEntity : class, IEntity
    {
        private MemberExpression expression;

        public HasRequiredSpec(Expression<Func<TEntity, object>> expression)
        {
            this.expression = (MemberExpression)expression.Body;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => p != null && !GetMemberValue(expression.Member, p).IsNullOrEmpty());
        }

        private object GetMemberValue(MemberInfo member, TEntity p)
        {
            return ((PropertyInfo)member).GetValue(p, null);
        }
    }
}
