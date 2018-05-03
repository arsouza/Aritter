using Ritter.Application.Services;
using Ritter.Domain.Validations;
using Ritter.Infra.Crosscutting;
using Ritter.Samples.Domain;
using System;
using System.Collections.Generic;
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

        public async Task AddValidEmployee()
        {
            Employee employee = new Employee("Anderson", "Ritter", "019.570.190-93");
            EmployeeValidator validator = new EmployeeValidator();

            ValidationResult result = validator.Validate(new Employee("Anderson", "Ritter", "019.570.190-93"));
            ValidationResult result2 = validator.Validate(new Employee("", "Ritter", "019.570.190-93"));

            Ensure.That<InvalidOperationException>(result.IsValid, result.Errors.Join(", "));

            await employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployee(int id)
        {
            try
            {
                employeeRepository.UnitOfWork.BeginTransaction();

                Employee employee = await employeeRepository.GetAsync(id);
                EmployeeValidator validator = new EmployeeValidator();

                ValidationResult result = validator.Validate(employee);
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
