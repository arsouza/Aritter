using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Validations.Rules
{
    public sealed class RangeRule<TValidable, TProp> : PropertyRule<TValidable, TProp> where TValidable : class where TProp : struct
    {
        private readonly TProp min;
        private readonly TProp max;

        public RangeRule(Expression<Func<TValidable, TProp>> expression, TProp min, TProp max) : this(expression, min, max, null) { }

        public RangeRule(Expression<Func<TValidable, TProp>> expression, TProp min, TProp max, string message) : base(expression, message)
        {
            this.min = min;
            this.max = max;
        }

        public override bool Validate(TValidable entity)
        {
            MinRule<TValidable, TProp> minRule = new MinRule<TValidable, TProp>(Expression, min);
            MaxRule<TValidable, TProp> maxRule = new MaxRule<TValidable, TProp>(Expression, max);

            return minRule.Validate(entity) && maxRule.Validate(entity);
        }
    }
}
