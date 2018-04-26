using Ritter.Domain.Seedwork.Validation;

namespace Ritter.Domain.Seedwork.Validation.Caching
{
    public interface IValidationContractCacheProvider
    {
        void AddItem(string key, ValidationContract value);
        ValidationContract GetItem(string key);
    }
}
