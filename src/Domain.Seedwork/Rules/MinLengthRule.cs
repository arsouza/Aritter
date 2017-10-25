using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class MinLengthRule<TEntity> : PropertyRule<TEntity, string>
        where TEntity : class
    {
        protected int minLength;

        public MinLengthRule(Expression<Func<TEntity, string>> expression, int minLength)
            : this(expression, minLength, null)
        {
        }

        public MinLengthRule(Expression<Func<TEntity, string>> expression, int minLength, string message)
            : base(expression, message)
        {
            this.minLength = minLength;
        }

        public override bool Validate(TEntity entity)
        {
            string value = Compile(entity);

            if (value.IsNullOrEmpty() && minLength > 0)
                return false;

            return value.Length >= minLength;
        }
    }
}
