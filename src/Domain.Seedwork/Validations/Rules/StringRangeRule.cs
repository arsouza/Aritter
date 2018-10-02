using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Validations.Rules
{
    public sealed class StringRangeRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class
    {
        private readonly int min;
        private readonly int max;

        public StringRangeRule(Expression<Func<TValidable, string>> expression, int min, int max) : this(expression, min, max, null) { }

        public StringRangeRule(Expression<Func<TValidable, string>> expression, int min, int max, string message) : base(expression, message)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(TValidable entity)
        {
            string value = Compile(entity);

            if (value.IsNullOrEmpty() && min > 0)
                return false;

            return value.Length <= max && value.Length >= min;
        }
    }
}
