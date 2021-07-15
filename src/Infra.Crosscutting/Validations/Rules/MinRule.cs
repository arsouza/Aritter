using System;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class MinRule<TValidable, TProp> : PropertyRule<TValidable, TProp>
        where TValidable : class
    {
        private readonly TProp minValue;

        public MinRule(Expression<Func<TValidable, TProp>> expression, TProp minValue) : this(expression, minValue, null) { }

        public MinRule(Expression<Func<TValidable, TProp>> expression, TProp minValue, string message) : base(expression, message)
        {
            Ensure.ArgumentNotNull(minValue, nameof(minValue));
            this.minValue = minValue;
        }

        public override bool IsValid(TValidable entity)
        {
            TProp value = Compile(entity);

            if (value is IComparable<TProp> genericComparable)
            {
                return genericComparable.CompareTo(minValue) >= 0;
            }

            if (value is IComparable comparable)
            {
                return comparable.CompareTo(minValue) >= 0;
            }

            throw new ArgumentException($"{typeof(TProp).FullName} does not implement IComparable.");
        }
    }
}
