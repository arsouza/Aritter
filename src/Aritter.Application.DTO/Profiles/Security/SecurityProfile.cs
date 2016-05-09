using Aritter.Application.DTO.Security;
using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Users;
using AutoMapper;

namespace Aritter.Application.DTO.Profiles.Security
{
	public class SecurityProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Authentication, AuthenticationDTO>();
			CreateMap<Authorization, AuthorizationDTO>();
			CreateMap<Resource, ResourceDTO>();
			CreateMap<Menu, MenuDTO>();
			CreateMap<Module, ModuleDTO>();
			CreateMap<Permission, PermissionDTO>();
			CreateMap<Role, RoleDTO>();
			CreateMap<User, UserDTO>();
			CreateMap<UserPassword, UserPasswordDTO>();
		}
	}
}
