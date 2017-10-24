using Ritter.Domain.Seedwork.Rules.Validation;

namespace Ritter.Domain.Seedwork.Rules
{
    public abstract class ValidationRule<TEntity> : IValidationRule<TEntity>
        where TEntity : class
    {
        public ValidationRule()
        {
        }

        public ValidationRule(string message)
            : this()
        {
            Message = message;
        }

        public ValidationRule(string property, string message)
            : this(message)
        {
            Property = property;
        }

        public virtual string Message { get; protected set; }
        public virtual string Property { get; protected set; }

        public abstract bool Validate(TEntity entity);
    }
}
