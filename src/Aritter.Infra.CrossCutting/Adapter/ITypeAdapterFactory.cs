namespace Aritter.Infra.CrossCutting.Adapter
{
	public interface ITypeAdapterFactory
	{
		ITypeAdapter Create();
	}
}