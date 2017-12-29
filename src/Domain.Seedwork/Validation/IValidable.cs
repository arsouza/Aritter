namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidable
    {
        IValidationContract<TValidable> SetupValidation<TValidable>() where TValidable : class, IValidable;
    }
}