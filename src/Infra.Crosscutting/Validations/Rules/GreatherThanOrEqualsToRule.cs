using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class GreatherThanOrEqualsToRule<TValidable, TProp> : PropertyRule<TValidable, TProp>
        where TValidable : class
    {
        private readonly TProp value;

        public GreatherThanOrEqualsToRule(Expression<Func<TValidable, TProp>> expression, TProp value) : this(expression, value, null) { }

        public GreatherThanOrEqualsToRule(Expression<Func<TValidable, TProp>> expression, TProp value, string message) : base(expression, message)
        {
            Ensure.ArgumentNotNull(value, nameof(value));
            this.value = value;
        }

        public override bool IsValid(TValidable entity)
        {
            TProp compiledValue = Compile(entity);

            if (compiledValue is IComparable<TProp> genericComparable)
            {
                return genericComparable.CompareTo(value) >= 0;
            }

            if (compiledValue is IComparable comparable)
            {
                return comparable.CompareTo(value) >= 0;
            }

            throw new ArgumentException($"{typeof(TProp).FullName} does not implement IComparable.");
        }
    }

    public sealed class LessThanOrEqualsToRule<TValidable, TProp> : PropertyRule<TValidable, TProp>
        where TValidable : class
    {
        private readonly TProp value;

        public LessThanOrEqualsToRule(Expression<Func<TValidable, TProp>> expression, TProp value) : this(expression, value, null) { }

        public LessThanOrEqualsToRule(Expression<Func<TValidable, TProp>> expression, TProp value, string message) : base(expression, message)
        {
            Ensure.ArgumentNotNull(value, nameof(value));
            this.value = value;
        }

        public override bool IsValid(TValidable entity)
        {
            TProp value = Compile(entity);

            if (value is IComparable<TProp> genericComparable)
            {
                return genericComparable.CompareTo(this.value) <= 0;
            }

            if (value is IComparable comparable)
            {
                return comparable.CompareTo(this.value) <= 0;
            }

            throw new ArgumentException($"{typeof(TProp).FullName} does not implement IComparable.");
        }
    }
}
