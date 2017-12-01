using Ritter.Application.Seedwork.Services;
using Ritter.Samples.Domain;
using System.Threading.Tasks;

namespace Ritter.Samples.Application
{
    public interface IEmployeeAppService : IAppService
    {
        Task<Employee> AddValidEmployee();
        Task<Employee> AddInvalidEmployee();
        Task UpdateEmployee(int id);
    }
}
