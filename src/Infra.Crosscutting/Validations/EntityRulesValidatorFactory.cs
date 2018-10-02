namespace Ritter.Infra.Crosscutting.Validations
{
    public class EntityRulesValidatorFactory : IEntityValidatorFactory
    {
        public IEntityValidator Create()
        {
            return new EntityRulesValidator();
        }
    }
}
