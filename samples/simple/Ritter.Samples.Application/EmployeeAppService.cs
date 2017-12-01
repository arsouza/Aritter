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
                employeeRepository.UnitOfWork.BeginTransaction();

                Employee employee = new Employee("Test", "01957019093");
                var validation = employee.Validate();

                if (!validation.IsValid)
                    throw new InvalidOperationException(validation.Errors.Join(", "));

                await employeeRepository.AddAsync(employee);

                employeeRepository.UnitOfWork.Commit();

                return employee;
            }
            catch (Exception)
            {
                employeeRepository.UnitOfWork.Rollback();
                return null;
            }
        }

        public async Task<Employee> AddInvalidEmployee()
        {
            try
            {
                employeeRepository.UnitOfWork.BeginTransaction();

                Employee employee = new Employee("", null);
                var validation = employee.Validate();

                if (!validation.IsValid)
                    throw new InvalidOperationException(validation.Errors.Join(", "));

                await employeeRepository.AddAsync(employee);

                employeeRepository.UnitOfWork.Commit();

                return employee;
            }
            catch (Exception)
            {
                employeeRepository.UnitOfWork.Rollback();
                return null;
            }
        }

        public async Task UpdateEmployee(int id)
        {
            try
            {
                employeeRepository.UnitOfWork.BeginTransaction();

                var employee = await employeeRepository.GetAsync(id);

                employee.ChangeName("New name");
                var validation = employee.ValidateRequiredFields();

                EmployeeRulesEvaluator eval = new EmployeeRulesEvaluator();
                eval.Evaluate(employee);

                if (!validation.IsValid)
                    throw new InvalidOperationException(validation.Errors.Join(", "));

                await employeeRepository.UpdateAsync(employee);

                employeeRepository.UnitOfWork.Commit();
            }
            catch (Exception)
            {
                employeeRepository.UnitOfWork.Rollback();
            }
        }
    }
}
