namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidable<TValidable> : IValidable where TValidable : class, IValidable<TValidable>
    {
        void SetupValidation(ValidationContract<TValidable> contract);
    }
}
