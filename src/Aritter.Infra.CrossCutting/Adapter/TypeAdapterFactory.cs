namespace Aritter.Infra.Crosscutting.Adapter
{
    public static class TypeAdapterFactory
    {
        #region Members

        private static ITypeAdapterFactory currentTypeAdapterFactory = null;

        #endregion

        #region Public Static Methods

        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            currentTypeAdapterFactory = adapterFactory;
        }

        public static ITypeAdapter CreateAdapter()
        {
            return currentTypeAdapterFactory.Create();
        }

        #endregion
    }
}