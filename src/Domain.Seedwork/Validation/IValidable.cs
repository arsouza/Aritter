namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidable
    {
        IValidationContract<TValidable> ConfigureValidation<TValidable>() where TValidable : class, IValidable;
    }
}