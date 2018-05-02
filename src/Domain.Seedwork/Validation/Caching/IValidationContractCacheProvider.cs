using Ritter.Domain.Validation;

namespace Ritter.Domain.Validation.Caching
{
    public interface IValidationContractCacheProvider
    {
        void AddItem(string key, ValidationContract value);
        ValidationContract GetItem(string key);
    }
}
