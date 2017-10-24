using Ritter.Application.Seedwork.Services;
using Ritter.Samples.Domain;
using System;
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
            try
            {
                Employee employee = new Employee("Test");

                EmployeeValidator validator = new EmployeeValidator();
                var validation = validator.Validate(employee);

                if (validation.IsValid)
                {
                    await employeeRepository.AddAsync(employee);
                    return employee;
                }

                throw new InvalidOperationException(string.Join(", ", validation.Errors));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Employee> AddInvalidEmployee()
        {
            try
            {
                Employee employee = new Employee("");

                EmployeeValidator validator = new EmployeeValidator();
                var validation = validator.Validate(employee);

                if (validation.IsValid)
                {
                    await employeeRepository.AddAsync(employee);
                    return employee;
                }

                throw new InvalidOperationException(string.Join(", ", validation.Errors));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task UpdateEmployee(int id)
        {
            try
            {
                var employee = await employeeRepository.GetAsync(id);

                employee.ChangeName("New name");

                EmployeeValidator validator = new EmployeeValidator();
                var validation = validator.ValidateRequiredFields(employee);

                EmployeeRulesEvaluator eval = new EmployeeRulesEvaluator();
                eval.Evaluate(employee);

                if (validation.IsValid)
                {
                    await employeeRepository.UpdateAsync(employee);
                }

                throw new InvalidOperationException(string.Join(", ", validation.Errors));
            }
            catch (Exception)
            {
            }
        }
    }
}
