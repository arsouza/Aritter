using Ritter.Infra.Crosscutting.Validations.Rules;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Infra.Crosscutting.Validations
{
    public abstract class ValidationContext
    {
        protected readonly List<IValidationRule> rules;
        protected readonly List<LambdaExpression> includes;

        public ValidationContext()
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
            Ensure.Argument.NotNull(expression, nameof(expression));
            includes.Add(expression);
        }

        public void IncludeMany<TValidatable, TProp>(Expression<Func<TValidatable, TProp>> expression)
            where TValidatable : class, IValidatable
            where TProp : IEnumerable<IValidatable>
        {
            Ensure.Argument.NotNull(expression, nameof(expression));
            includes.Add(expression);
        }

        internal void AddRule<TValidatable>(IValidationRule<TValidatable> rule)
            where TValidatable : class
        {
            Ensure.Argument.NotNull(rule, nameof(rule));
            rules.Add(rule);
        }
    }
}
