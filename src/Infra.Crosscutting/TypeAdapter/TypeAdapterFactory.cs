namespace Ritter.Infra.Crosscutting.TypeAdapter
{
    public static class TypeAdapterFactory
    {
        static ITypeAdapterFactory currentFactory = null;

        public static void SetCurrent(ITypeAdapterFactory typeAdapterFactory)
        {
            currentFactory = typeAdapterFactory;
        }

        public static ITypeAdapter CreateAdapter()
        {
            return currentFactory.Create();
        }
    }
}
