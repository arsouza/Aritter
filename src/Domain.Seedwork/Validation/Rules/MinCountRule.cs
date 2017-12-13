using System;
using System.Collections;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public sealed class MinCountRule<TEntity> : PropertyRule<TEntity, ICollection>
        where TEntity : class
    {
        private readonly int minCount;

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

            if (collection is null && minCount > 0)
                return false;

            return collection.Count >= minCount;
        }
    }
}
