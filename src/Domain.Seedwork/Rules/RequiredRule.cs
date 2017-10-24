using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class RequiredRule<TEntity, TProp> : PropertyRule<TEntity, TProp>
        where TEntity : class
    {
        public RequiredRule(Expression<Func<TEntity, TProp>> expression)
            : this(expression, null)
        {
        }

        public RequiredRule(Expression<Func<TEntity, TProp>> expression, string message)
            : base(expression, message)
        {
        }

        public override bool Validate(TEntity entity)
        {
            if (typeof(TProp) == typeof(string))
                return !string.IsNullOrEmpty(Compile(entity) as string);

            return Compile(entity) != null;
        }
    }
}
