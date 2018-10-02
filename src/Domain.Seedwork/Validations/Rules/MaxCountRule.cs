using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Validations.Rules
{
    public sealed class MaxCountRule<TValidable> : PropertyRule<TValidable, ICollection> where TValidable : class
    {
        private readonly int maxCount;

        public MaxCountRule(Expression<Func<TValidable, ICollection>> expression, int maxCount) : this(expression, maxCount, null) { }

        public MaxCountRule(Expression<Func<TValidable, ICollection>> expression, int maxCount, string message) : base(expression, message)
        {
            this.maxCount = maxCount;
        }

        public override bool IsValid(TValidable entity)
        {
            ICollection collection = Compile(entity);

            if (collection.IsNull())
                return true;

            return collection.Count <= maxCount;
        }
    }
}
