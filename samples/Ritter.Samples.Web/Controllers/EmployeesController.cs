using Microsoft.AspNetCore.Mvc;
using Ritter.Application.Models;
using Ritter.Infra.Http;
using Ritter.Samples.Application.DTO.Employees.Request;
using Ritter.Samples.Application.DTO.Employees.Response;
using Ritter.Samples.Application.Services.Employees;
using System.Net;
using System.Threading.Tasks;

namespace Ritter.Samples.Web.Controllers
{
    /// <summary>
    /// Everything about Employees
    /// </summary>
    [Route("api/[controller]")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeAppService employeeAppService;

        public EmployeesController(IEmployeeAppService employeeAppService)
        {
            this.employeeAppService = employeeAppService;
        }

        /// <summary>
        /// List all employees
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/employees?pageIndex=0&amp;pageSize=10&amp;orderByName=FirstName&amp;ascending=true
        ///
        /// </remarks>
        /// <param name="pageFilter">Page filter</param>
        /// <returns>A list of employees</returns>
        /// <response code="200">If the search has sucesss</response> 
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<GetEmployeeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(PagingFilter pageFilter) => Ok(await employeeAppService.ListEmployees(pageFilter));

        /// <summary>
        /// Get an employee by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/employees/1
        ///
        /// </remarks>
        /// <param name="employeeId">Employee identifier</param>
        /// <returns>The employee</returns>
        /// <response code="201">If the employee added successfully</response> 
        /// <response code="404">If the employee has not found</response> 
        [HttpGet]
        [Route("{employeeId:int}", Name = "GetEmployee")]
        [ProducesResponseType(typeof(GetEmployeeDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int employeeId) => OkOrNotFound(await employeeAppService.GetEmployee(employeeId));

        /// <summary>
        /// Add an employee
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/employees
        ///     {
        ///         "firstName": "string",
        ///         "lastName": "string",
        ///         "cpf": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="employeeDto">Employee data</param>
        /// <returns>The added employee</returns>
        /// <response code="201">If the employee has added successfully</response> 
        /// <response code="400">If the employee data is not valid</response> 
        [HttpPost]
        [ProducesResponseType(typeof(GetEmployeeDto), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddEmployeeDto employeeDto)
        {
            var employee = await employeeAppService.AddEmployee(employeeDto);
            return CreatedAtRoute(
                routeName: "GetEmployee",
                routeValues: new { employeeId = employee.EmployeeId },
                value: employee);
        }

        /// <summary>
        /// Update an employee
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/employees/1
        ///     {
        ///         "firstName": "string",
        ///         "lastName": "string",
        ///         "cpf": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="employeeId">Employee identifier</param>
        /// <param name="employeeDto">Employee data</param>
        /// <returns>The added employee</returns>
        /// <response code="202">If the employee has added successfully</response> 
        /// <response code="400">If the employee data is not valid</response> 
        /// <response code="404">If the employee has added successfully</response> 
        [HttpPatch]
        [Route("{employeeId:int}")]
        [ProducesResponseType(typeof(GetEmployeeDto), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Patch(int employeeId, [FromBody] UpdateEmployeeDto employeeDto)
        {
            var employee = await employeeAppService.UpdateEmployee(employeeId, employeeDto);
            return AcceptedAtRoute(
                routeName: "GetEmployee",
                routeValues: new { employeeId = employee.EmployeeId },
                value: employee);
        }
    }
}
