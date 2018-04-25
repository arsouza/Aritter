using Ritter.Domain.Seedwork.Validation;
using Ritter.Infra.Crosscutting.Caching;

namespace Domain.Seedwork.Validation.Caching
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
