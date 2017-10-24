using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class MaxCountRule<TEntity> : PropertyRule<TEntity, ICollection>
        where TEntity : class
    {
        protected int maxCount;

        public MaxCountRule(Expression<Func<TEntity, ICollection>> expression, int maxCount)
            : this(expression, maxCount, null)
        {
        }

        public MaxCountRule(Expression<Func<TEntity, ICollection>> expression, int maxCount, string message)
            : base(expression, message)
        {
            this.maxCount = maxCount;
        }

        public override bool Validate(TEntity entity)
        {
            ICollection collection = Compile(entity);

            if (collection == null)
                return true;

            return collection.Count <= maxCount;
        }
    }
}
