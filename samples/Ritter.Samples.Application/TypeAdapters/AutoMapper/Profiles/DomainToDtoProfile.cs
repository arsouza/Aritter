using AutoMapper;
using Ritter.Samples.Application.DTO.Employees.Response;
using Ritter.Samples.Domain.Aggregates.Employees;

namespace Ritter.Samples.Application.TypeAdapters.AutoMapper.Profiles
{
    internal class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Employee, GetEmployeeDto>()
                .ForMember(d => d.EmployeeId, opt => opt.MapFrom(p => p.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(p => p.Name.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(p => p.Name.LastName));
        }
    }
}
