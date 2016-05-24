using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class MaxLengthRule<T> : GenericRule<T, string>
    {
        protected int maxLength;

        public MaxLengthRule(Expression<Func<T, string>> expression, int naxLength)
            : base(expression)
        {
            this.maxLength = naxLength;
        }

        public MaxLengthRule(Func<T, string> provider, int maxLength)
            : base(provider)
        {
            this.maxLength = maxLength;
        }

        public override bool Validate(Func<T> source)
        {
            string value = provider(source());

            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return value.Length <= maxLength;
        }
    }
}
