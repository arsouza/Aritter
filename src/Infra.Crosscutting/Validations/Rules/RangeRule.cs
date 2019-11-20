using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class RangeRule<TValidable, TProp> : PropertyRule<TValidable, TProp>
        where TValidable : class
    {
        private readonly TProp min;
        private readonly TProp max;

        public RangeRule(Expression<Func<TValidable, TProp>> expression, TProp min, TProp max) : this(expression, min, max, null) { }

        public RangeRule(Expression<Func<TValidable, TProp>> expression, TProp min, TProp max, string message) : base(expression, message)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(TValidable entity)
        {
            MinRule<TValidable, TProp> minRule = new MinRule<TValidable, TProp>(Expression, min);
            MaxRule<TValidable, TProp> maxRule = new MaxRule<TValidable, TProp>(Expression, max);

            return minRule.IsValid(entity) && maxRule.IsValid(entity);
        }
    }
}
