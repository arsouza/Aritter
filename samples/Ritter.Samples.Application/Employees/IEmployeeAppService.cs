using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.Employees.Request;
using Ritter.Samples.Application.DTO.Employees.Response;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.Employees
{
    public interface IEmployeeAppService : IAppService
    {
        Task<GetEmployeeDto> AddEmployee(AddEmployeeDto employeeDto);
        Task<GetEmployeeDto> UpdateEmployee(int employeeId, UpdateEmployeeDto employeeDto);
    }
}
