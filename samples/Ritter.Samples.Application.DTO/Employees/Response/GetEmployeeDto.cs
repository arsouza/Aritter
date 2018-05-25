using System;

namespace Ritter.Samples.Application.DTO.Employees.Response
{
    public class GetEmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public Guid Uid { get; set; }
    }
}
