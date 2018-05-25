using Ritter.Infra.Data.Query;
using Ritter.Samples.Application.DTO.Employees.Response;

namespace Ritter.Samples.Infra.Data.Query.Repositories.Employee
{
    public interface IEmployeeQueryRepository : IQueryRepository<GetEmployeeDto>
    {
    }
}
