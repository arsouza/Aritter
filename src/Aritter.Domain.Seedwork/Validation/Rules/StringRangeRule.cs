using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class StringRangeRule<T> : GenericRule<T, string>
    {
        protected int min;
        protected int max;

        public StringRangeRule(Expression<Func<T, string>> expression, int min, int max) 
            : base(expression)
        {
            this.min = min;
            this.max = max;
        }

        public StringRangeRule(Func<T, string> provider, int min, int max) 
            : base(provider)
        {
            this.min = min;
            this.max = max;
        }

        public override bool Validate(Func<T> source)
        {
            string value = provider(source());

            if(string.IsNullOrEmpty(value) && min > 0)
            {
                return false;
            }
            return value.Length <= max && value.Length >= min;
        }
    }
}
