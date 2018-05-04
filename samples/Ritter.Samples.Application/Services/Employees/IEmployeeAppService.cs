using Ritter.Application.Models;
using Ritter.Application.Services;
using Ritter.Samples.Application.DTO.Employees.Response;
using System.Threading.Tasks;

namespace Ritter.Samples.Application.Services.Employees
{
    public interface IEmployeeAppService : IAppService
    {
        Task AddValidEmployee();
        Task UpdateEmployee(int id);
        Task<PagedResult<GetEmployeeDto>> ListEmployees(PagingFilter pageFilter);
    }
}
