namespace Ritter.Infra.Crosscutting.TypeAdapter
{
    public static class TypeAdapterFactory
    {
        static ITypeAdapterFactory currentFactory = null;

        public static void SetCurrent(ITypeAdapterFactory typeAdapterFactory)
        {
            Ensure.NotNull(typeAdapterFactory, $"The value of {nameof(typeAdapterFactory)} cannot be null.");
            currentFactory = typeAdapterFactory;
        }

        public static ITypeAdapter CreateAdapter()
        {
            return currentFactory.Create();
        }
    }
}
