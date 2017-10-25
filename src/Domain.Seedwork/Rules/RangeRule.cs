using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class RangeRule<TEntity, TProp> : PropertyRule<TEntity, TProp>
        where TEntity : class
        where TProp : struct
    {
        protected TProp min;
        protected TProp max;

        public RangeRule(Expression<Func<TEntity, TProp>> expression, TProp min, TProp max)
            : this(expression, min, max, null)
        {
        }

        public RangeRule(Expression<Func<TEntity, TProp>> expression, TProp min, TProp max, string message)
            : base(expression, message)
        {
            this.min = min;
            this.max = max;
        }

        public override bool Validate(TEntity entity)
        {
            MinRule<TEntity, TProp> minRule = new MinRule<TEntity, TProp>(Expression, min);
            MaxRule<TEntity, TProp> maxRule = new MaxRule<TEntity, TProp>(Expression, max);

            return minRule.Validate(entity) && maxRule.Validate(entity);
        }
    }
}
