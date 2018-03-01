using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class MaxCountRule<TValidable> : PropertyRule<TValidable, ICollection> where TValidable : class, IValidable<TValidable>
    {
        private readonly int maxCount;

        public MaxCountRule(Expression<Func<TValidable, ICollection>> expression, int maxCount) : this(expression, maxCount, null) { }

        public MaxCountRule(Expression<Func<TValidable, ICollection>> expression, int maxCount, string message) : base(expression, message)
        {
            this.maxCount = maxCount;
        }

        public override bool Validate(TValidable entity)
        {
            ICollection collection = Compile(entity);

            if (collection is null)
                return true;

            return collection.Count <= maxCount;
        }
    }
}