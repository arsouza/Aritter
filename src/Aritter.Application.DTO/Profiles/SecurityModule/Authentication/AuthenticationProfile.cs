using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Domain.SecurityModule.Aggregates.PermissionAgg;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Infra.Crosscutting.Security;
using AutoMapper;
using System;
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
                    src.UserAssignments
                    .SelectMany(p => p.Role.Authorizations)
                    .Select(ParsePermission)
                    .Distinct()))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src =>
                    src.UserAssignments
                    .Select(p => p.Role.Name)
                    .Distinct()));
        }

        private string ParsePermission(Authorization authorization)
        {
            var rule = Rule.None;
            Enum.TryParse(authorization.Permission.Operation.Name, out rule);

            return $"{authorization.Permission.Resource.Name}:{rule}";
        }
    }
}
