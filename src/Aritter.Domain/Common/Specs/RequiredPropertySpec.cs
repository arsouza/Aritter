using Aritter.Domain.Seedwork;
using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Aritter.Domain.Common.Specs
{
    public sealed class RequiredPropertySpec<TEntity> : Specification<TEntity>
          where TEntity : class, IEntity
    {
        private MemberExpression expression;

        public RequiredPropertySpec<TEntity> Property<TProperty>(Expression<Func<TEntity, TProperty>> expression)
        {
            this.expression = (MemberExpression)expression.Body;
            return this;
        }

        public override Expression<Func<TEntity, bool>> SatisfiedBy()
        {
            return (p => !GetMemberValue(expression.Member, p).IsNullOrEmpty());
        }

        private object GetMemberValue(MemberInfo member, TEntity p)
        {
            return ((PropertyInfo)member).GetValue(p, null);
        }
    }
}
