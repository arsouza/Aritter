using Ritter.Domain.Seedwork.Rules.Validation;

namespace Ritter.Domain.Seedwork
{
    public interface IValidable<TEntity> where TEntity : class
    {
        ValidationResult Validate();
    }
}