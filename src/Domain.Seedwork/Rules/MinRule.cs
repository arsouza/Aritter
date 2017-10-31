using System;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public sealed class MinRule<TEntity, TProp> : PropertyRule<TEntity, TProp>
        where TEntity : class
        where TProp : struct
    {
        private readonly TProp minValue;

        public MinRule(Expression<Func<TEntity, TProp>> expression, TProp minValue)
            : this(expression, minValue, null)
        {
        }

        public MinRule(Expression<Func<TEntity, TProp>> expression, TProp minValue, string message)
            : base(expression, message)
        {
            this.minValue = minValue;
        }

        public override bool Validate(TEntity entity)
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
