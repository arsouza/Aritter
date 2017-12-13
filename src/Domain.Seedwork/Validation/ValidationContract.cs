using System;
using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Validation
{
    public sealed class ValidationContract<TValidable> where TValidable : class
    {
        private List<IValidationRule<TValidable>> rules;

        public ValidationContract()
        {
            rules = new List<IValidationRule<TValidable>>();
        }

        public IReadOnlyCollection<IValidationRule<TValidable>> Rules { get { return rules; } }

        internal void AddRule(IValidationRule<TValidable> rule)
        {
            if (rule is null)
                throw new ArgumentNullException(nameof(rule));

            rules.Add(rule);
        }
    }
}