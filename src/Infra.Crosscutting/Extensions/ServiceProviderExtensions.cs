namespace System
{
    public static class ServiceProviderExtensions
    {
        public static TType GetService<TType>(this IServiceProvider serviceProvider)
            where TType : class
            => serviceProvider.GetService(typeof(TType)) as TType;
    }
}
