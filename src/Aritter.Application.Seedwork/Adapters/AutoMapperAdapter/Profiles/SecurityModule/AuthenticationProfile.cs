using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using AutoMapper;

namespace Aritter.Application.Seedwork.Adapters.AutoMapperAdapter.Profiles.SecurityModule
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<UserAccount, UserAccountDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserProfile.FullName))
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID));

            CreateMap<Authorization, AuthorizationDto>()
                .ForMember(dest => dest.Application, opt => opt.MapFrom(src => src.Permission.Resource.Application.Name))
                .ForMember(dest => dest.Resource, opt => opt.MapFrom(src => src.Permission.Resource.Name))
                .ForMember(dest => dest.Operation, opt => opt.MapFrom(src => src.Permission.Operation.Name));
        }
    }
}
