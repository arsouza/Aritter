using Ritter.Infra.Crosscutting;
using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Validations.Rules
{
    public sealed class MaxRule<TValidable, TProp> : PropertyRule<TValidable, TProp> where TValidable : class where TProp : struct
    {
        private readonly TProp maxValue;

        public MaxRule(Expression<Func<TValidable, TProp>> expression, TProp maxValue) : this(expression, maxValue, null) { }

        public MaxRule(Expression<Func<TValidable, TProp>> expression, TProp maxValue, string message) : base(expression, message)
        {
            Ensure.Argument.NotNull(maxValue, nameof(maxValue));
            this.maxValue = maxValue;
        }

        public override bool IsValid(TValidable entity)
        {
            TProp value = Compile(entity);

            if (value is IComparable<TProp> genericComparable)
                return genericComparable.CompareTo(maxValue) <= 0;

            if (value is IComparable comparable)
                return comparable.CompareTo(maxValue) <= 0;

            throw new ArgumentException($"{typeof(TProp).FullName} does not implement IComparable.");
        }
    }
}
