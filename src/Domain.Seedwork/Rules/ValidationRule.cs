using Ritter.Domain.Seedwork.Rules.Validation;

namespace Ritter.Domain.Seedwork.Rules
{
    public abstract class ValidationRule<TEntity> : IValidationRule<TEntity>
        where TEntity : class
    {
        public ValidationRule(string property, string message)
            : this(message)
        {
            Property = property;
        }

        public ValidationRule(string message)

        {
            Message = message;
        }

        public string Message { get; protected set; }
        public string Property { get; protected set; }

        public abstract bool Validate(TEntity entity);
    }
}
