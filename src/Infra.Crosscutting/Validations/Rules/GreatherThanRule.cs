using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class GreatherThanRule<TValidable, TProp> : PropertyRule<TValidable, TProp>
        where TValidable : class
    {
        private readonly TProp value;

        public GreatherThanRule(Expression<Func<TValidable, TProp>> expression, TProp value) : this(expression, value, null) { }

        public GreatherThanRule(Expression<Func<TValidable, TProp>> expression, TProp value, string message) : base(expression, message)
        {
            Ensure.ArgumentNotNull(value, nameof(value));
            this.value = value;
        }

        public override bool IsValid(TValidable entity)
        {
            TProp value = Compile(entity);

            if (value is IComparable<TProp> genericComparable)
            {
                return genericComparable.CompareTo(this.value) > 0;
            }

            if (value is IComparable comparable)
            {
                return comparable.CompareTo(this.value) > 0;
            }

            throw new ArgumentException($"{typeof(TProp).FullName} does not implement IComparable.");
        }
    }

    public sealed class LessThanRule<TValidable, TProp> : PropertyRule<TValidable, TProp>
        where TValidable : class
    {
        private readonly TProp value;

        public LessThanRule(Expression<Func<TValidable, TProp>> expression, TProp value) : this(expression, value, null) { }

        public LessThanRule(Expression<Func<TValidable, TProp>> expression, TProp value, string message) : base(expression, message)
        {
            Ensure.ArgumentNotNull(value, nameof(value));
            this.value = value;
        }

        public override bool IsValid(TValidable entity)
        {
            TProp value = Compile(entity);

            if (value is IComparable<TProp> genericComparable)
            {
                return genericComparable.CompareTo(this.value) < 0;
            }

            if (value is IComparable comparable)
            {
                return comparable.CompareTo(this.value) < 0;
            }

            throw new ArgumentException($"{typeof(TProp).FullName} does not implement IComparable.");
        }
    }
}
