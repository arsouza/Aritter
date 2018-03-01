using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Domain.Seedwork.Validation
{
    public abstract class ValidationContract
    {
        protected List<IValidationRule> rules;
        protected List<KeyValuePair<Type, LambdaExpression>> includes;

        public ValidationContract()
        {
            rules = new List<IValidationRule>();
            includes = new List<KeyValuePair<Type, LambdaExpression>>();
        }

        public IReadOnlyCollection<IValidationRule> Rules { get { return rules; } }
        public IReadOnlyCollection<KeyValuePair<Type, LambdaExpression>> Includes { get { return includes; } }
    }
}
