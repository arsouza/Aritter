namespace Aritter.Domain.Seedwork.Specs
{
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
         where TEntity : class, IEntity
    {
        #region Properties

        public abstract ISpecification<TEntity> LeftSideSpecification { get; }

        public abstract ISpecification<TEntity> RightSideSpecification { get; }

        #endregion
    }
}
