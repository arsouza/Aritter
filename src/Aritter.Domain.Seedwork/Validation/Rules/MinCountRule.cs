using System;
using System.Collections;
using System.Linq.Expressions;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class MinCountRule<T> : GenericRule<T, ICollection>
    {
        protected int minCount;

        public MinCountRule(Expression<Func<T, ICollection>> expression, int minCount) 
            : base(expression)
        {
            this.minCount = minCount;
        }

        public MinCountRule(Func<T, ICollection> provider, int minCount) 
            : base(provider)
        {
            this.minCount = minCount;
        }

        public override bool Validate(Func<T> source)
        {
            ICollection collection = provider(source());

            if(collection == null && minCount > 0)
            {
                return false;
            }
            return collection.Count >= minCount;
        }
    }
}
