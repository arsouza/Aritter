namespace Aritter.Infra.Crosscutting.Adapter
{
    public static class TypeAdapterFactory
    {
        private static ITypeAdapterFactory currentFactory = null;

        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            currentFactory = adapterFactory;
        }

        public static ITypeAdapter CreateAdapter()
        {
            return currentFactory?.Create();
        }
    }
}
