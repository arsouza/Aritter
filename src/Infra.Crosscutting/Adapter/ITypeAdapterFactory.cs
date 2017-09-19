namespace Ritter.Infra.Crosscutting.Adapter
{
    public interface ITypeAdapterFactory
	{
		ITypeAdapter Create();
	}
}