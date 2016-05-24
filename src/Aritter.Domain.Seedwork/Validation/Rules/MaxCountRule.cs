using System;
using System.Collections;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class MaxCountRule<T> : GenericRule<T, ICollection>
    {
        protected int maxCount;

        public MaxCountRule(Expression<Func<T, ICollection>> expression, int maxCount) : base(expression)
        {
            this.maxCount = maxCount;
        }

        public MaxCountRule(Func<T, ICollection> provider, int maxCount) : base(provider)
        {
            this.maxCount = maxCount;
        }

        public override bool Validate(Func<T> source)
        {
            ICollection collection = provider(source());

            if (collection == null)
            {
                return true;
            }
            return collection.Count <= maxCount;
        }
    }
}
