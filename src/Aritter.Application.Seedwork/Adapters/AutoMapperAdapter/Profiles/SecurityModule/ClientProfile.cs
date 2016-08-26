using Aritter.Application.DTO.SecurityModule;
using AutoMapper;

namespace Aritter.Application.Seedwork.Adapters.AutoMapperAdapter.Profiles.SecurityModule
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Domain.SecurityModule.Aggregates.Client, ClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID));
        }
    }
}
