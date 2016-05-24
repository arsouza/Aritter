using System.Collections.Generic;

namespace Aritter.Domain.Seedwork.Validation
{
    public interface IValidatableEntity : IEntity
    {
        Dictionary<string, Feature<IValidatableEntity>> Features { get; }
        Feature<IValidatableEntity> Configuration { get; }
        void ConfigureFeatures();
    }
}
