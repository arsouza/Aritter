namespace Ritter.Infra.Crosscutting.Specifications
{
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
         where TEntity : class
    {
        protected CompositeSpecification(ISpecification<TEntity> leftSideSpecification, ISpecification<TEntity> rightSideSpecification)
        {
            Ensure.Argument.NotNull(leftSideSpecification, nameof(leftSideSpecification));
            Ensure.Argument.NotNull(rightSideSpecification, nameof(rightSideSpecification));

            LeftSideSpecification = leftSideSpecification;
            RightSideSpecification = rightSideSpecification;
        }

        public ISpecification<TEntity> LeftSideSpecification { get; }

        public ISpecification<TEntity> RightSideSpecification { get; }
    }
}
