namespace Aritter.Domain.Seedwork.Validation
{
    public class DomainEntityValidatorFactory : IEntityValidatorFactory
    {
        public IEntityValidator Create()
        {
            return new DomainEntityValidator();
        }
    }
}
