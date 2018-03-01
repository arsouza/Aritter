using Ritter.Infra.Crosscutting.Extensions;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class MaxLengthRule<TValidable> : PropertyRule<TValidable, string> where TValidable : class, IValidable<TValidable>
    {
        private readonly int maxLength;

        public MaxLengthRule(Expression<Func<TValidable, string>> expression, int maxLength) : this(expression, maxLength, null) { }

        public MaxLengthRule(Expression<Func<TValidable, string>> expression, int maxLength, string message) : base(expression, message)
        {
            this.maxLength = maxLength;
        }

        public override bool Validate(TValidable entity)
        {
            string value = Compile(entity);

            if (value.IsNullOrEmpty())
                return true;

            return value.Length <= maxLength;
        }
    }
}