using Aritter.Infras.Crosscutting.Exceptions;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class MinRule<T, TProp> : GenericRule<T, TProp> where TProp : struct
    {
        protected TProp minValue;

        public MinRule(Expression<Func<T, TProp>> expression, TProp minValue)
            : base(expression)
        {
            this.minValue = minValue;
        }

        public MinRule(Func<T, TProp> provider, TProp minValue)
            : base(provider)
        {
            this.minValue = minValue;
        }

        public override bool Validate(Func<T> source)
        {
            TProp value = provider(source());

            IComparable<TProp> genericComparable = value as IComparable<TProp>;

            if (genericComparable != null)
            {
                return genericComparable.CompareTo(minValue) >= 0;
            }

            IComparable comparable = value as IComparable;

            if (comparable != null)
            {
                return comparable.CompareTo(minValue) >= 0;
            }

            ThrowHelper.ThrowArgumentException(true, $"{typeof(TProp).FullName} does not implement IComparable.");
            return false;
        }
    }
}
