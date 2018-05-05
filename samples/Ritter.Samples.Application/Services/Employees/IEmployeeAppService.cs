using Ritter.Application.Models;
using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.Employees.Request;
using Ritter.Samples.Application.DTO.Employees.Response;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.Services.Employees
{
    public interface IEmployeeAppService : IAppService
    {
        Task<PagedResult<GetEmployeeDto>> ListEmployees(PagingFilter pageFilter);
        Task<GetEmployeeDto> GetEmployee(int employeeId);
        Task<GetEmployeeDto> AddEmployee(PostEmployeeDto employeeDto);
    }
}
