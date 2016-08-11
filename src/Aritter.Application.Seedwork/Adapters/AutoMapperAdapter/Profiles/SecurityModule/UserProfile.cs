using Aritter.Application.DTO.SecurityModule.Users;
using Aritter.Domain.SecurityModule.Aggregates.Users;
using AutoMapper;

namespace Aritter.Application.Seedwork.Adapters.AutoMapperAdapter.Profiles.SecurityModule
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserAccount, UserAccountDto>()
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserProfile.Name))
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
				.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
		}
	}
}
