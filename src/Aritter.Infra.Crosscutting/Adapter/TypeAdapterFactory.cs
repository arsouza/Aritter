namespace Aritter.Infra.Crosscutting.Adapter
{
    public static class TypeAdapterFactory
    {
        #region Members

        private static ITypeAdapterFactory currentFactory = null;

        #endregion

        #region Public Static Methods

        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            currentFactory = adapterFactory;
        }

        public static ITypeAdapter CreateAdapter()
        {
            return currentFactory.Create();
        }

        #endregion
    }
}