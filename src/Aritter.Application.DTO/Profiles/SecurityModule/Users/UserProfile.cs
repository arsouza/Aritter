using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Domain.SecurityModule.Aggregates.Users;

namespace Aritter.Application.DTO.Profiles.SecurityModule.Users
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Profile.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Profile.LastName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UID, opt => opt.MapFrom(src => src.UID))
                .ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(src => src.Enabled))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
        }
    }
}
