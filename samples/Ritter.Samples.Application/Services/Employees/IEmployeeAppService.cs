using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.Base;
using Ritter.Samples.Application.DTO.Employees.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.Services.Employees
{
    public interface IEmployeeAppService : IAppService
    {
        Task AddValidEmployee();
        Task UpdateEmployee(int id);
        Task<ICollection<GetEmployeeDto>> ListEmployees(PageFilter pageFilter);
    }
}
