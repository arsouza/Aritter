using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class StringRangeRule<TEntity> : PropertyRule<TEntity, string>
        where TEntity : class
    {
        protected int min;
        protected int max;

        public StringRangeRule(Expression<Func<TEntity, string>> expression, int min, int max)
            : this(expression, min, max, null)
        {
        }

        public StringRangeRule(Expression<Func<TEntity, string>> expression, int min, int max, string message)
            : base(expression, message)
        {
            this.min = min;
            this.max = max;
        }

        public override bool Validate(TEntity entity)
        {
            string value = Compile(entity);

            if (value.IsNullOrEmpty() && min > 0)
            {
                return false;
            }
            return value.Length <= max && value.Length >= min;
        }
    }
}
