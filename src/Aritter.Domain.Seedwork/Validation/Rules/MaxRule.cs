using Aritter.Infra.Crosscutting.Exceptions;
using System;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class MaxRule<T, TProp> : GenericRule<T, TProp> where TProp : struct
    {
        protected TProp maxValue;

        public MaxRule(Expression<Func<T, TProp>> expression, TProp maxValue)
            : base(expression)
        {
            this.maxValue = maxValue;
        }

        public MaxRule(Func<T, TProp> provider, TProp maxValue)
            : base(provider)
        {
            this.maxValue = maxValue;
        }

        public override bool Validate(Func<T> source)
        {
            TProp value = provider(source());

            IComparable<TProp> genericComparable = value as IComparable<TProp>;

            if (genericComparable != null)
            {
                return genericComparable.CompareTo(maxValue) <= 0;
            }

            IComparable comparable = value as IComparable;

            if (comparable != null)
            {
                return comparable.CompareTo(maxValue) <= 0;
            }

            ThrowHelper.ThrowArgumentException(true, $"{typeof(TProp).FullName} does not implement IComparable.");
            return false;
        }
    }
}
