namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidationRule<in TValidable> where TValidable : class, IValidable
    {
        string Property { get; }
        string Message { get; }

        bool Validate(TValidable entity);
    }
}