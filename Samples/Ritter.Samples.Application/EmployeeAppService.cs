using Ritter.Application.Seedwork.Services;
using Ritter.Samples.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Ritter.Samples.Application
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeAppService(IEmployeeRepository employeeRepository)
            : base(null)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<Employee> TestAddAndUpdate()
        {
            Employee employee = new Employee("Test");
            await employeeRepository.AddAsync(employee);

            employee.ChangeName("Test2");
            await employeeRepository.UpdateAsync(employee);

            return await employeeRepository.GetAsync(employee.Id);
        }

        public async Task TestUpdate(int id)
        {
            //var employee = await employeeRepository.GetAsync(id);
            var employees = await employeeRepository.FindAsync();

            employees.First().ChangeName("New name");
            await employeeRepository.UpdateAsync(employees.First());
        }
    }
}
