using Ritter.Domain.Seedwork.Validation;

namespace Domain.Seedwork.Validation.Caching
{
    public interface IValidationContractCacheProvider
    {
        void AddItem(string key, ValidationContract value);
        ValidationContract GetItem(string key);
    }
}
