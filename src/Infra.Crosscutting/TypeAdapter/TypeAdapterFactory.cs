namespace Ritter.Infra.Crosscutting.TypeAdapter
{
    public static class TypeAdapterFactory
    {
        static ITypeAdapterFactory factory = null;

        public static void UseFactory(ITypeAdapterFactory typeAdapterFactory)
        {
            Ensure.NotNull(typeAdapterFactory, $"The value of {nameof(typeAdapterFactory)} cannot be null.");
            factory = typeAdapterFactory;
        }
        
        public static void UseFactory<TTypeAdapterFactory>()
            where TTypeAdapterFactory : class, ITypeAdapterFactory, new()
        {
            UseFactory(new TTypeAdapterFactory());
        }

        public static ITypeAdapter CreateAdapter()
        {
            return factory.Create();
        }
    }
}
