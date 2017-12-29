using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Infra.Crosscutting.Extensions;
using Ritter.Samples.Domain;
using System;
using System.Threading.Tasks;

namespace Ritter.Samples.Application
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IEntityValidator entityValidator;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeAppService(IEmployeeRepository employeeRepository, IEntityValidator entityValidator) : base(null)
        {
            this.employeeRepository = employeeRepository;
            this.entityValidator = entityValidator;
        }

        public async Task<Employee> AddValidEmployee()
        {
            try
            {
                employeeRepository.UnitOfWork.BeginTransaction();

                Employee employee = new Employee("Test", "Test", "019.570.190-93");

                ValidationResult result = entityValidator.Validate(employee);

                if (!result.IsValid)
                    throw new InvalidOperationException(result.Errors.Join(", "));

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

                Employee employee = await employeeRepository.GetAsync(id);
                employee.Identify("New first name", "New last name");

                ValidationResult result = entityValidator.Validate(employee);

                if (!result.IsValid)
                    throw new InvalidOperationException(result.Errors.Join(", "));

                await employeeRepository.UpdateAsync(employee);
            }
            catch (Exception)
            {
                employeeRepository.UnitOfWork.Rollback();
            }
        }
    }
}