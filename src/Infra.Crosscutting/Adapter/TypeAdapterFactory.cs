namespace Ritter.Infra.Crosscutting.Adapter
{
    public static class TypeAdapterFactory
    {
        private static ITypeAdapterFactory current = null;

        public static void SetCurrent(ITypeAdapterFactory typeAdapterFactory)
        {
            current = typeAdapterFactory;
        }

        public static ITypeAdapter CreateAdapter()
        {
            return current?.Create();
        }
    }
}
