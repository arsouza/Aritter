using Aritter.Application.DTO.Security;
using Aritter.Domain.Security.Aggregates;
using AutoMapper;

namespace Aritter.Application.DTO.Profiles.Security
{
    public class SecurityProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
