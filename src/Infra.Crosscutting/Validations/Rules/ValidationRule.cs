namespace Ritter.Infra.Crosscutting.Validations.Rules
{
    public abstract class ValidationRule : IValidationRule
    {
        protected ValidationRule(string property, string message)
            : this(message)
        {
            Property = property;
        }

        protected ValidationRule(string message)
        {
            Message = message;
        }

        public string Message { get; protected set; }

        public string Property { get; protected set; }

        public abstract bool IsValid(object entity);
    }
}
