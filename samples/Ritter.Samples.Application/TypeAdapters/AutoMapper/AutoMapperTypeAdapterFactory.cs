using AutoMapper;
using Ritter.Infra.Crosscutting.TypeAdapter;
using Ritter.Samples.Application.TypeAdapters.AutoMapper.Profiles;

namespace Ritter.Samples.Application.TypeAdapters.AutoMapper
{
    public class AutoMapperTypeAdapterFactory : ITypeAdapterFactory
    {
        public AutoMapperTypeAdapterFactory()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<DomainToDtoProfile>();
                config.AddProfile<DtoToDomainProfile>();
            });
        }

        public ITypeAdapter Create()
        {
            return new AutoMapperTypeAdapter();
        }
    }
}
