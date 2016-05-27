#region license



#endregion

using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Exceptions;
using System;

namespace Aritter.Domain.Seedwork.Validation.Rules
{
    public class ValidationRule<TEntity> : SpecificationRuleBase<TEntity>, IValidationRule<TEntity>
        where TEntity : class, IEntity
    {
        private readonly string _message;
        private readonly string _property;

        public ValidationRule(ISpecification<TEntity> rule, string message, string property) : base(rule)
        {
            Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(message), "Please provide a valid non null value for the validationMessage parameter.");
            Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(property), "Please provide a valid non null value for the validationProperty parameter.");
            _message = message;
            _property = property;
        }

        public string ValidationMessage
        {
            get { return _message; }
        }

        public string ValidationProperty
        {
            get { return _property; }
        }

        public bool Validate(TEntity entity)
        {
            return IsSatisfied(entity);
        }
    }
}
