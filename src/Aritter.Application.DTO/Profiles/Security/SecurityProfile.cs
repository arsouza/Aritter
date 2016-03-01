using Aritter.Application.DTO.Security;
using Aritter.Domain.Security.Aggregates;
using AutoMapper;

namespace Aritter.Application.DTO.Profiles.Security
{
    public class SecurityProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Authentication, AuthenticationDTO>();
            CreateMap<Authorization, AuthorizationDTO>();
            CreateMap<Feature, FeatureDTO>();
            CreateMap<Menu, MenuDTO>();
            CreateMap<Module, ModuleDTO>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleMenu, RoleMenuDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<UserPassword, UserPasswordDTO>();
            CreateMap<UserRole, UserRoleDTO>();
        }
    }
}
