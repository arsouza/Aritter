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

        public async Task<Employee> AddValidEmployee()
        {
            EmployeeValidator validator = new EmployeeValidator();

            Employee employee = new Employee("Test");
            var validation = validator.ValidateNewEmployee(employee);

            if (validation.IsValid)
            {
                await employeeRepository.AddAsync(employee);
                return employee;
            }

            return null;
        }

        public async Task<Employee> AddInvalidEmployee()
        {
            EmployeeValidator validator = new EmployeeValidator();

            Employee employee = new Employee("");
            var validation = validator.ValidateNewEmployee(employee);

            if (validation.IsValid)
            {
                await employeeRepository.AddAsync(employee);
                return employee;
            }

            return null;
        }

        public async Task UpdateEmployee(int id)
        {
            //var employee = await employeeRepository.GetAsync(id);
            var employees = await employeeRepository.FindAsync();

            employees.First().ChangeName("New name");
            await employeeRepository.UpdateAsync(employees.First());
        }
    }
}
