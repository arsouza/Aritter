using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class MaxLengthRule<TEntity> : PropertyRule<TEntity, string>
        where TEntity : class
    {
        private readonly int maxLength;

        public MaxLengthRule(Expression<Func<TEntity, string>> expression, int maxLength)
            : this(expression, maxLength, null)
        {
        }

        public MaxLengthRule(Expression<Func<TEntity, string>> expression, int maxLength, string message)
            : base(expression, message)
        {
            this.maxLength = maxLength;
        }

        public override bool Validate(TEntity entity)
        {
            string value = Compile(entity);

            if (value.IsNullOrEmpty())
                return true;

            return value.Length <= maxLength;
        }
    }
}
