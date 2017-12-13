namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidationRule<in TValidable>
    {
        string Property { get; }
        string Message { get; }

        bool Validate(TValidable entity);
    }
}
