using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.Employees.Request;
using Ritter.Samples.Application.DTO.Employees.Response;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.Employees
{
    public interface IEmployeeAppService : IAppService
    {
        Task<EmployeeDto> AddEmployee(AddEmployeeDto employeeDto);
        Task<EmployeeDto> UpdateEmployee(int employeeId, UpdateEmployeeDto employeeDto);
    }
}
