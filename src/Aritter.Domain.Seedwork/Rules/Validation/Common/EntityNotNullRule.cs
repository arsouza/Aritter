using Aritter.Domain.Seedwork.Specifications;

namespace Aritter.Domain.Seedwork.Rules.Validation.Common
{
    public sealed class EntityNotNullRule<TEntity> : ValidationRule<TEntity>
         where TEntity : class, IEntity
    {
        public EntityNotNullRule(string message)
            : base(new IsNotNullSpec<TEntity>(), message)
        {
        }

        public EntityNotNullRule(string message, string property)
            : base(new IsNotNullSpec<TEntity>(), message, property)
        {
        }
    }
}
