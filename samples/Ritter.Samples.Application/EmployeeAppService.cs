using Ritter.Application.Services;
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

        public async Task AddValidEmployee()
        {
            try
            {
                var employee = new Employee("", "", "019.570.190-93");
                var validator = new EmployeeValidator();

                var result = validator.Validate(employee);
                result.EnsureValid();

                await employeeRepository.AddAsync(employee);
            }
            catch (Exception)
            {
            }
        }

        public async Task UpdateEmployee(int id)
        {
            try
            {
                employeeRepository.UnitOfWork.BeginTransaction();

                var employee = await employeeRepository.GetAsync(id);
                var validator = new EmployeeValidator();

                var result = validator.Validate(employee);
                result.EnsureValid();

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
