using Ritter.Application.Shared;
using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.Employees.Request;
using Ritter.Samples.Application.DTO.Employees.Response;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.Services.Employees
{
    public interface IEmployeeAppService : IAppService
    {
        Task<PagedResult<GetEmployeeDto>> ListEmployees(PaginationFilter pageFilter);
        Task<GetEmployeeDto> GetEmployee(int employeeId);
        Task<GetEmployeeDto> AddEmployee(AddEmployeeDto employeeDto);
        Task<GetEmployeeDto> UpdateEmployee(int employeeId, UpdateEmployeeDto employeeDto);
    }
}
