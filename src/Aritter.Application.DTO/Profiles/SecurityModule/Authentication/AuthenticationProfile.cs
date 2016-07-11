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
                    src.Roles
                    .SelectMany(p => p.Role.Authorizations)
                    .Select(p => $"{p.Permission.Resource.Name}:{(int)p.Permission.Rule}")
                    .Distinct()))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src =>
                    src.Roles
                    .Select(p => p.Role.Name)
                    .Distinct()));

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
                .ForMember(dest => dest.Identity, opt => opt.MapFrom(src => src.Identity));
        }
    }
}
