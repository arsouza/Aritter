using Aritter.Domain.Seedwork.Specifications;

namespace Aritter.Domain.Seedwork.Rules.Validation.Common
{
    public sealed class EntityNullRule<TEntity> : ValidationRule<TEntity>
         where TEntity : class, IEntity
    {
        public EntityNullRule(string message)
            : base(new IsNullSpec<TEntity>(), message)
        {
        }

        public EntityNullRule(string message, string property)
            : base(new IsNullSpec<TEntity>(), message, property)
        {
        }
    }
}
