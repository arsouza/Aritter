using Aritter.Infra.Crosscutting.Adapter;

namespace Aritter.Infra.Crosscutting.Tests.Adapter
{
    public class TestTypeAdapterFactory : ITypeAdapterFactory
    {
        ITypeAdapter typeAdapter;

        public ITypeAdapter Create()
        {
            return typeAdapter ?? (typeAdapter = new TestTypeAdapter());
        }
    }
}