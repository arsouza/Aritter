using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public sealed class MaxRule<TEntity, TProp> : PropertyRule<TEntity, TProp>
        where TEntity : class
        where TProp : struct
    {
        private readonly TProp maxValue;

        public MaxRule(Expression<Func<TEntity, TProp>> expression, TProp maxValue)
            : this(expression, maxValue, null)
        {
        }

        public MaxRule(Expression<Func<TEntity, TProp>> expression, TProp maxValue, string message)
            : base(expression, message)
        {
            this.maxValue = maxValue;
        }

        public override bool Validate(TEntity entity)
        {
            TProp value = Compile(entity);

            if (value is IComparable<TProp> genericComparable)
            {
                return genericComparable.CompareTo(maxValue) <= 0;
            }

            if (value is IComparable comparable)
            {
                return comparable.CompareTo(maxValue) <= 0;
            }

            throw new ArgumentException($"{typeof(TProp).FullName} does not implement IComparable.");
        }
    }
}
