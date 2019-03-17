namespace Ritter.Infra.Crosscutting.Validations
{
    public interface IEntityValidatorFactory
    {
        IEntityValidator Create();
    }
}
