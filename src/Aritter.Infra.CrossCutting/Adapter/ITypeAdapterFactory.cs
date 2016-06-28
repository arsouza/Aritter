namespace Aritter.Infra.Crosscutting.Adapter
{
    public interface ITypeAdapterFactory
	{
		ITypeAdapter Create();
	}
}