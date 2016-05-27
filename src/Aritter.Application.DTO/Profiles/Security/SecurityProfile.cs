using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using AutoMapper;

namespace Aritter.Application.DTO.Profiles.Security
{
    public class SecurityProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<User, AuthorizationDto>();
        }
    }
}
