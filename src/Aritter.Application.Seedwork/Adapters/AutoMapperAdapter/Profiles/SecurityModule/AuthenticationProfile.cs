using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.Seedwork.Extensions;
using Aritter.Domain.SecurityModule.Aggregates.Permissions;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using Aritter.Infra.Crosscutting.Security;
using AutoMapper;
using System;
using System.Linq;

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
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserProfile.Name))
				.ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID));

			CreateMap<UserAccount, AuthorizationDto>()
				.ForMember(dest => dest.User, opt => opt.MapFrom(user => user.ProjectedAs<UserAccountDto>()))
				.ForMember(dest => dest.Permissions, opt => opt.MapFrom(src => src.Assignments
					.SelectMany(p => p.UserRole.Authorizations)
					.Select(ParsePermission)
					.Distinct()))
				.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Assignments
					.Select(p => p.UserRole.Name)
					.Distinct()));
		}

		private UserAccountDto ParseUserAccountDto(UserAccount userAccount)
		{
			return new UserAccountDto
			{
				Id = userAccount.Id,
				Email = userAccount.Email,
				Name = userAccount.UserProfile.Name,
				UID = userAccount.UID,
				Username = userAccount.Username
			};
		}

		private string ParsePermission(Authorization authorization)
		{
			var rule = Rule.None;
			Enum.TryParse(authorization.Permission.Operation.Name, out rule);

			return $"{authorization.Permission.Resource.Name}:{rule}";
		}
	}
}
