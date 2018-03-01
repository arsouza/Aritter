using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class MinLengthRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class, IValidable<TValidable>
    {
        private readonly int minLength;

        public MinLengthRule(Expression<Func<TValidable, string>> expression, int minLength) : this(expression, minLength, null) { }

        public MinLengthRule(Expression<Func<TValidable, string>> expression, int minLength, string message) : base(expression, message)
        {
            this.minLength = minLength;
        }

        public override bool Validate(TValidable entity)
        {
            string value = Compile(entity);

            if (value.IsNullOrEmpty() && minLength > 0)
                return false;

            return value.Length >= minLength;
        }
    }
}