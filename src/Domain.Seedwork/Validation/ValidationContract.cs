using System;
using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Validation
{
    public sealed class ValidationContext<TEntity> where TEntity : class
    {
        private List<IValidationRule<TEntity>> rules;

        public ValidationContext()
        {
            rules = new List<IValidationRule<TEntity>>();
        }

        public IReadOnlyCollection<IValidationRule<TEntity>> Rules { get { return rules; } }

        internal void AddRule(IValidationRule<TEntity> rule)
        {
            if (rule is null)
                throw new ArgumentNullException(nameof(rule));

            rules.Add(rule);
        }
    }
}