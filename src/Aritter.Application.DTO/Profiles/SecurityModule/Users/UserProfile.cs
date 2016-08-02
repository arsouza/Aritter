using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using AutoMapper;

namespace Aritter.Application.DTO.Profiles.SecurityModule.Users
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDto>()
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
				.ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
				.ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(src => src.IsEnabled))
				.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
		}
	}
}
