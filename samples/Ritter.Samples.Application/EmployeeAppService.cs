using Ritter.Application.Services;
using Ritter.Domain.Validation;
using Ritter.Domain.Validation.Fluent;
using Ritter.Infra.Crosscutting;
using Ritter.Samples.Domain;
using System;
using System.Collections.Generic;
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

                Employee employee = new Employee("Anderson", "Ritter", "019.570.190-93");

                ValidationResult result = entityValidator.Validate(new Employee("Anderson", "Ritter", "019.570.190-93"));
                ValidationResult result2 = entityValidator.Validate(new Employee("", "Ritter", "019.570.190-93"));

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
