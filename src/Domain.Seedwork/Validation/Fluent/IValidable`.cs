namespace Ritter.Domain.Seedwork.Validation.Fluent
{
    public interface IValidable<TValidable> : IValidable where TValidable : class, IValidable<TValidable>
    {
        void SetupValidation(ValidationContract<TValidable> contract);
    }
}
