namespace Ritter.Infra.Crosscutting.Validations
{
    public static class EntityValidatorFactory
    {
        static IEntityValidatorFactory factory = null;

        public static void UseFactory(IEntityValidatorFactory factory)
        {
            EntityValidatorFactory.factory = factory;
        }

        public static IEntityValidator CreateValidator()
        {
            return factory?.Create();
        }
    }
}
