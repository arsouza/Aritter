using Ritter.Application.Seedwork.Services;
using Ritter.Samples.Domain;
using System.Threading.Tasks;

namespace Ritter.Samples.Application
{
    public interface IEmployeeAppService : IAppService
    {
        Task AddValidEmployee();
        Task UpdateEmployee(int id);
    }
}
