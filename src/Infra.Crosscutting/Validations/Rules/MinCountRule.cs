using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public sealed class MinCountRule<TValidable, TEnumerable> : PropertyRule<TValidable, ICollection<TEnumerable>> where TValidable : class
    {
        private readonly int minCount;

        public MinCountRule(Expression<Func<TValidable, ICollection<TEnumerable>>> expression, int minCount) : this(expression, minCount, null) { }

        public MinCountRule(Expression<Func<TValidable, ICollection<TEnumerable>>> expression, int minCount, string message) : base(expression, message)
        {
            Ensure.ArgumentNotNull(minCount, nameof(minCount));
            this.minCount = minCount;
        }

        public override bool IsValid(TValidable entity)
        {
            ICollection<TEnumerable> collection = Compile(entity);
            return (collection?.Count).GetValueOrDefault() >= minCount;
        }
    }
}
