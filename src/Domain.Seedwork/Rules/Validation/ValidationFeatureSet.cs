using System.Collections.Generic;

namespace Ritter.Domain.Seedwork.Rules.Validation
{
    public sealed class ValidationFeatureSet<TEntity>
        where TEntity : class
    {
        public IDictionary<string, ValidationFeature<TEntity>> Features { get; } = new Dictionary<string, ValidationFeature<TEntity>>();
    }
}
