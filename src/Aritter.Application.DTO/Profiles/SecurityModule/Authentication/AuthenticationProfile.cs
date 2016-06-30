using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using AutoMapper;
using System.Linq;

namespace Aritter.Application.DTO.Profiles.SecurityModule
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<User, AuthenticationDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src =>
                    src.UserRoles
                    .SelectMany(p => p.Role.Authorizations)
                    .Select(p => p.Permission.Resource.Name)
                    .Distinct()))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src =>
                    src.UserRoles
                    .Select(p => p.Role.Name)
                    .Distinct()));

            CreateMap<User, UserDto>();
        }
    }
}
