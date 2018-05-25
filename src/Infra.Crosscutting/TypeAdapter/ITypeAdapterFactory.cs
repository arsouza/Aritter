namespace Ritter.Infra.Crosscutting.TypeAdapter
{
    public interface ITypeAdapterFactory
    {
        ITypeAdapter Create();
    }
}
