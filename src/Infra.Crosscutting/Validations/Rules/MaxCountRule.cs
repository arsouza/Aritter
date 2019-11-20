using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class MaxCountRule<TValidable, TEnumerable> : PropertyRule<TValidable, ICollection<TEnumerable>> where TValidable : class
    {
        private readonly int maxCount;

        public MaxCountRule(Expression<Func<TValidable, ICollection<TEnumerable>>> expression, int maxCount) : this(expression, maxCount, null) { }

        public MaxCountRule(Expression<Func<TValidable, ICollection<TEnumerable>>> expression, int maxCount, string message) : base(expression, message)
        {
            this.maxCount = maxCount;
        }

        public override bool IsValid(TValidable entity)
        {
            ICollection<TEnumerable> collection = Compile(entity);

            if (collection is null)
                return true;

            return collection.Count <= maxCount;
        }
    }
}
