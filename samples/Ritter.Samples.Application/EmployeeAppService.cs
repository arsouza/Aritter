using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork.Validation;
using Ritter.Domain.Seedwork.Validation.Fluent;
using Ritter.Infra.Crosscutting;
using Ritter.Infra.Crosscutting.Extensions;
using Ritter.Samples.Domain;
using System;
using System.Threading.Tasks;

namespace Ritter.Samples.Application
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IFluentValidator entityValidator;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeAppService(IEmployeeRepository employeeRepository, IFluentValidator entityValidator) : base(null)
        {
            this.employeeRepository = employeeRepository;
            this.entityValidator = entityValidator;
        }

        public async Task AddValidEmployee()
        {
            try
            {
                employeeRepository.UnitOfWork.BeginTransaction();

                Employee employee = new Employee("", "Test", "019.570.190-93");

                ValidationResult result = entityValidator.Validate(employee);
                Ensure.That<InvalidOperationException>(result.IsValid, result.Errors.Join(", "));

                await employeeRepository.AddAsync(employee);
                employeeRepository.UnitOfWork.Commit();
            }
            catch (Exception)
            {
                employeeRepository.UnitOfWork.Rollback();
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
                Ensure.That<InvalidOperationException>(result.IsValid, result.Errors.Join(", "));

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
