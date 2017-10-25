using Ritter.Application.Seedwork.Services;
using Ritter.Infra.Crosscutting.Extensions;
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
                var validation = employee.Validate();

                if (validation.IsValid)
                {
                    await employeeRepository.AddAsync(employee);
                    return employee;
                }

                throw new InvalidOperationException(validation.Errors.Join(", "));
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
                var validation = employee.Validate();

                if (validation.IsValid)
                {
                    await employeeRepository.AddAsync(employee);
                    return employee;
                }

                throw new InvalidOperationException(validation.Errors.Join(", "));
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
                var validation = employee.ValidateRequiredFields();

                EmployeeRulesEvaluator eval = new EmployeeRulesEvaluator();
                eval.Evaluate(employee);

                if (validation.IsValid)
                {
                    await employeeRepository.UpdateAsync(employee);
                }

                throw new InvalidOperationException(validation.Errors.Join(", "));
            }
            catch (Exception)
            {
            }
        }
    }
}
