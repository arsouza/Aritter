using Aritter.Application.DTO.SecurityModule;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Domain.SecurityModule.Aggregates;
using AutoMapper;

namespace Aritter.Application.Seedwork.Adapters.AutoMapperAdapter.Profiles.SecurityModule
{
    public class SecurityProfile : Profile
    {
        public SecurityProfile()
        {
            CreateMap<UserAccount, UserAccountDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserProfile.FullName))
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID));

            CreateMap<Permission, PermissionDto>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Resource.Client.Name))
                .ForMember(dest => dest.Resource, opt => opt.MapFrom(src => src.Resource.Name))
                .ForMember(dest => dest.Operation, opt => opt.MapFrom(src => src.Operation.Name))
                .ForMember(dest => dest.Authorizations, opt => opt.MapFrom(src => src.Authorizations.ProjectedAsCollection<AuthorizationDto>()));

            CreateMap<Authorization, AuthorizationDto>()
                .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.UserRole.Name))
                .ForMember(dest => dest.Allowed, opt => opt.MapFrom(src => src.Allowed))
                .ForMember(dest => dest.Denied, opt => opt.MapFrom(src => src.Denied));

            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID));
        }
    }
}
