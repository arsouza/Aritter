namespace Ritter.Infra.Crosscutting.Validations
{
    public class Validatable<TValidatable> : IValidatable<TValidatable> where TValidatable : class
    {
        public virtual void AddValidations(ValidationContext<TValidatable> context)
        {
        }

        public void AddValidations(ValidationContext context)
        {
            AddValidations((ValidationContext<TValidatable>)context);
        }
    }
}
