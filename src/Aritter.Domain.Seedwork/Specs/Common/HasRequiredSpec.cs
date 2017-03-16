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
            return (p => p != null && GetMemberValue(expression.Member, p) != null);
        }

        private object GetMemberValue(MemberInfo member, TEntity entity)
        {
            return ((PropertyInfo)member).GetValue(entity, null);
        }
    }
}
