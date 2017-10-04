namespace Ritter.Domain.Seedwork.Specs
{
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
         where TEntity : class
    {
        public abstract ISpecification<TEntity> LeftSideSpecification { get; }

        public abstract ISpecification<TEntity> RightSideSpecification { get; }
    }
}
