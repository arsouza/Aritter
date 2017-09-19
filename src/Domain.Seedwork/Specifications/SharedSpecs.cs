namespace Ritter.Domain.Seedwork.Specifications
{
    public static class SharedSpecs
    {
        public static Specification<TEntity> True<TEntity>()
             where TEntity : class
        {
            return new TrueSpecification<TEntity>();
        }
    }
}
