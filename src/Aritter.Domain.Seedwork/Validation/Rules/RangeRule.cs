using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class RangeRule<T, TProp> : GenericRule<T, TProp> where TProp : struct
    {
        protected TProp min;
        protected TProp max;

        public RangeRule(Expression<Func<T, TProp>> expression, TProp min, TProp max) 
            : base(expression)
        {
            this.min = min;
            this.max = max;
        }

        public RangeRule(Func<T, TProp> provider, TProp min, TProp max)
            : base(provider)
        {
            this.min = min;
            this.max = max;
        }

        public override bool Validate(Func<T> source)
        {
            MinRule<T, TProp> minRule = new MinRule<T, TProp>(provider, min);
            MaxRule<T, TProp> maxRule = new MaxRule<T, TProp>(provider, max);

            return minRule.Validate(source) && maxRule.Validate(source);
        }
    }
}
