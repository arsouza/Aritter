using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
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
            TProp compiledValue = Compile(entity);

            if (compiledValue is IComparable<TProp> genericComparable)
            {
                return genericComparable.CompareTo(value) < 0;
            }

            if (compiledValue is IComparable comparable)
            {
                return comparable.CompareTo(value) < 0;
            }

            throw new ArgumentException($"{typeof(TProp).FullName} does not implement IComparable.");
        }
    }
}
