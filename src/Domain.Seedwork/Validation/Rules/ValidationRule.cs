using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation.Rules
{
    public abstract class ValidationRule<TValidable> : IValidationRule<TValidable> where TValidable : class, IValidable
    {
        protected ValidationRule(string property, string message) : this(message)
        {
            Property = property;
        }

        protected ValidationRule(string message)

        {
            Message = message;
        }

        public string Message { get; protected set; }
        public string Property { get; protected set; }

        public abstract bool Validate(TValidable entity);
    }
}