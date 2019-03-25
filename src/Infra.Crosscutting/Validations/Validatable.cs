namespace Ritter.Infra.Crosscutting.Validations
{
    public class Validatable<TValidatable> : IValidatable<TValidatable> where TValidatable : class
    {
        public virtual void AddValidations(ValidationContext<TValidatable> context)
        {
        }

        public void AddValidations(ValidationContext context)
        {
            this.AddValidations((ValidationContext<TValidatable>)context);
        }
    }
}
