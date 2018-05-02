using Ritter.Domain.Validation;
using Ritter.Infra.Crosscutting.Caching;

namespace Ritter.Domain.Validation.Caching
{
    public class ValidationContractCacheProvider : CacheProvider, IValidationContractCacheProvider
    {
        public void AddItem(string key, ValidationContract value)
        {
            base.AddItem(key, value);
        }

        public new ValidationContract GetItem(string key)
        {
            return base.GetItem(key) as ValidationContract;
        }
    }
}
