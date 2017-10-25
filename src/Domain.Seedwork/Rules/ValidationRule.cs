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

        public virtual string Message { get; protected set; }

        public abstract bool Validate(TEntity entity);

        public override string ToString()
        {
            return Message ?? base.ToString();
        }
    }
}
