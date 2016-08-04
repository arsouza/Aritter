using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Infra.Crosscutting.Security;
using System;
using System.Linq;

namespace Aritter.Application.DTO.Profiles.SecurityModule
{
    public class AuthenticationProfile : AutoMapper.Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<UserAccount, AuthenticationDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom(src =>
                    src.Assignments
                    .SelectMany(p => p.UserRole.Authorizations)
                    .Select(ParsePermission)
                    .Distinct()))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src =>
                    src.Assignments
                    .Select(p => p.UserRole.Name)
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
