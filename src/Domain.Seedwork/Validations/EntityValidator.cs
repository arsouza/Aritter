namespace Ritter.Domain.Validations
{
    public abstract class EntityValidator : IEntityValidator
    {
        public abstract ValidationResult Validate(object item);
    }
}
