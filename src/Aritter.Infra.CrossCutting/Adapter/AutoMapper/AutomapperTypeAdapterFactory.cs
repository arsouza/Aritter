using AutoMapper;

namespace Aritter.Infra.Crosscutting.Adapter.AutoMapper
{
    public class AutoMapperTypeAdapterFactory : ITypeAdapterFactory
    {
        #region

        private readonly MapperConfiguration configuration;

        #endregion

        #region Constructor

        public AutoMapperTypeAdapterFactory()
        {
            configuration = new MapperConfiguration(config =>
            {
                config.CreateMissingTypeMaps = true;
            });
        }

        #endregion

        #region ITypeAdapterFactory Members

        public ITypeAdapter Create()
        {
            return new AutoMapperTypeAdapter(configuration);
        }

        #endregion
    }

}