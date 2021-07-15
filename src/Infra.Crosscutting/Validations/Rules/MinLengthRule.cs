using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class MinLengthRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class
    {
        private readonly int minLength;

        public MinLengthRule(Expression<Func<TValidable, string>> expression, int minLength) : this(expression, minLength, null) { }

        public MinLengthRule(Expression<Func<TValidable, string>> expression, int minLength, string message) : base(expression, message)
        {
            Ensure.ArgumentNotNull(minLength, nameof(minLength));
            this.minLength = minLength;
        }

        public override bool IsValid(TValidable entity)
        {
            string value = Compile(entity);

            if (value.IsNullOrEmpty() && minLength > 0)
                return false;

            return value.Length >= minLength;
        }
    }
}
