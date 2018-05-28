using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Http;
using Ritter.Samples.Application.DTO.Employees.Request;
using Ritter.Samples.Application.DTO.Employees.Response;
using Ritter.Samples.Application.Employees;
using Ritter.Samples.Infra.Data.Query.Repositories.Employee;
using Ritter.Samples.Web.Models.Shared;
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
        private readonly IEmployeeQueryRepository employeeQueryRepository;

        public EmployeesController(
            IEmployeeAppService employeeAppService,
            IEmployeeQueryRepository employeeQueryRepository)
        {
            this.employeeAppService = employeeAppService;
            this.employeeQueryRepository = employeeQueryRepository;
        }

        /// <summary>
        /// List employees by filter
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/employees?pageIndex=0&amp;pageSize=10&amp;orderByName=FirstName&amp;ascending=true
        ///
        /// </remarks>
        /// <param name="pageFilter">The page filter</param>
        /// <returns>A list of employees</returns>
        /// <response code="200">The search has sucesss</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<EmployeeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(PaginationFilter pageFilter)
        {
            var employees = await employeeQueryRepository.FindAsync(pageFilter.GetPagination());
            return Ok(PagedResult.FromPagedCollection(employees));
        }

        /// <summary>
        /// Get an employee by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/employees/1
        ///
        /// </remarks>
        /// <param name="employeeId">The employee identifier</param>
        /// <returns>The employee found</returns>
        /// <response code="200">The employee was found</response>
        /// <response code="404">The employee was not found</response>
        [HttpGet]
        [Route("{employeeId:int}", Name = "GetEmployee")]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int employeeId) => OkOrNotFound(await employeeQueryRepository.GetAsync(employeeId));

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
        /// <param name="employeeDto">The employee data</param>
        /// <returns>The new employee</returns>
        /// <response code="201">The employee was successfully saved</response>
        /// <response code="400">The employee data sent is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.Created)]
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
        ///     PATCH /api/employees/1
        ///     {
        ///         "cpf": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="employeeId">The employee identifier</param>
        /// <param name="employeeDto">The employee data</param>
        /// <returns>The updated employee</returns>
        /// <response code="202">The employee was successfully saved</response>
        /// <response code="400">The employee data sent is invalid</response>
        /// <response code="404">The employee was not found</response>
        [HttpPatch]
        [Route("{employeeId:int}")]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.Accepted)]
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
