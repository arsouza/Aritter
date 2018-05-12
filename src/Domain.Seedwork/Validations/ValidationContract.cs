using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ritter.Domain.Validations
{
    public abstract class ValidationContract
    {
        protected List<IValidationRule> rules;
        protected List<KeyValuePair<IEntityValidator, LambdaExpression>> includes;

        protected ValidationContract()
        {
            rules = new List<IValidationRule>();
            includes = new List<KeyValuePair<IEntityValidator, LambdaExpression>>();
        }

        public IReadOnlyCollection<IValidationRule> Rules { get { return rules; } }

        public IReadOnlyCollection<KeyValuePair<IEntityValidator, LambdaExpression>> Includes => includes;
    }
}
