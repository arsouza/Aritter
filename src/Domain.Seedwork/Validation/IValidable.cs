using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation
{
    public interface IValidable<TEntity> where TEntity : class
    {
        ValidationResult Validate();
    }
}