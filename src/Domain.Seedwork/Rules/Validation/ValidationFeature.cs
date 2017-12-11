using System;
using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public sealed class ValidationFeature<TEntity> where TEntity : class
    {
        public ICollection<IValidationRule<TEntity>> Rules { get; } = new List<IValidationRule<TEntity>>();

        internal void AddRule(IValidationRule<TEntity> rule)
        {
            if (rule is null)
                throw new ArgumentNullException(nameof(rule));

            Rules.Add(rule);
        }
    }
}