using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Ritter.Infra.Crosscutting.Validations.Rules;

namespace Ritter.Infra.Crosscutting.Validations
{
    public abstract class ValidationContext
    {
        protected readonly List<IValidationRule> rules;
        protected readonly List<LambdaExpression> includes;

        protected ValidationContext()
        {
            rules = new List<IValidationRule>();
            includes = new List<LambdaExpression>();
        }

        public IReadOnlyCollection<IValidationRule> Rules => rules;

        public IReadOnlyCollection<LambdaExpression> Includes => includes;

        public void Include<TValidatable, TProp>(Expression<Func<TValidatable, TProp>> expression)
            where TValidatable : class, IValidatable
            where TProp : class, IValidatable
        {
            Ensure.ArgumentNotNull(expression, nameof(expression));
            includes.Add(expression);
        }

        public void Include<TValidatable, TProp>(Expression<Func<TValidatable, IEnumerable<TProp>>> expression)
            where TValidatable : class, IValidatable
            where TProp : IEnumerable<IValidatable>
        {
            Ensure.ArgumentNotNull(expression, nameof(expression));
            includes.Add(expression);
        }

        internal void AddRule<TValidatable>(IValidationRule<TValidatable> rule)
            where TValidatable : class
        {
            Ensure.ArgumentNotNull(rule, nameof(rule));
            rules.Add(rule);
        }
    }
}
