using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class MinLengthRule<T> : GenericRule<T, string>
    {
        protected int minLength;

        public MinLengthRule(Expression<Func<T, string>> expression, int minLength)
            : base(expression)
        {
            this.minLength = minLength;
        }

        public MinLengthRule(Func<T, string> provider, int minLength)
            : base(provider)
        {
            this.minLength = minLength;
        }

        public override bool Validate(Func<T> source)
        {
            string value = provider(source());

            if (string.IsNullOrEmpty(value) && minLength > 0)
            {
                return false;
            }
            return value.Length >= minLength;
        }
    }
}
