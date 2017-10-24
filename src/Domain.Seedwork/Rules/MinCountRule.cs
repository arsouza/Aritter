using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Rules
{
    public class MinCountRule<TEntity> : PropertyRule<TEntity, ICollection>
        where TEntity : class
    {
        protected int minCount;

        public MinCountRule(Expression<Func<TEntity, ICollection>> expression, int minCount)
            : this(expression, minCount, null)
        {
        }

        public MinCountRule(Expression<Func<TEntity, ICollection>> expression, int minCount, string message)
            : base(expression, message)
        {
            this.minCount = minCount;
        }

        public override bool Validate(TEntity entity)
        {
            ICollection collection = Compile(entity);

            if (collection == null && minCount > 0)
                return false;

            return collection.Count >= minCount;
        }
    }
}
