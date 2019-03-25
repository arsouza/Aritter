using Infra.Http.Seedwork.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Http.Requests;
using Ritter.Infra.Http.Responses;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;
using Ritter.Samples.Application.People;
using Ritter.Samples.Infra.Data.Query.Repositories.People;
using System;
using System.Threading.Tasks;

namespace Ritter.Samples.Web.Controllers
{
    /// <summary>
    /// Everything about People
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ApiController
    {
        private readonly IPersonAppService personAppService;
        private readonly IPersonQueryRepository personQueryRepository;

        public PeopleController(
            IPersonAppService personAppService,
            IPersonQueryRepository personQueryRepository)
        {
            this.personAppService = personAppService;
            this.personQueryRepository = personQueryRepository;
        }

        /// <summary>
        /// List people by filter
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/people?pageIndex=0&amp;pageSize=10&amp;orderByName=FirstName&amp;ascending=true
        ///
        /// </remarks>
        /// <param name="pageFilter">The page filter</param>
        /// <returns>A list of people</returns>
        /// <response code="200">The search has sucesss</response>
        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<PersonResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter pageFilter)
        {
            return Paged(await personQueryRepository.FindAsync(pageFilter.ToPagination()));
        }

        /// <summary>
        /// Get an person by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/people/1
        ///
        /// </remarks>
        /// <param name="personId">The person identifier</param>
        /// <returns>The person found</returns>
        /// <response code="200">The person was found</response>
        /// <response code="404">The person was not found</response>
        [HttpGet]
        [Route("{personId:long}", Name = "GetPerson")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(long personId)
        {
            var person = await personQueryRepository.FindAsync(personId);

            if (person.IsNull())
                return NotFound();

            return Ok(person);
        }

        /// <summary>
        /// Add an person
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/people
        ///     {
        ///         "firstName": "string",
        ///         "lastName": "string",
        ///         "cpf": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">The person data</param>
        /// <returns>The new person</returns>
        /// <response code="201">The person was successfully saved</response>
        /// <response code="400">The person data sent is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AddPersonRequest request)
        {
            PersonResponse person = await personAppService.AddPerson(request);

            return CreatedAtRoute(
                routeName: "GetPerson",
                routeValues: new { personId = person.PersonId },
                value: person);
        }

        /// <summary>
        /// Update an person
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PATCH /api/people/1
        ///     {
        ///         "cpf": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="personId">The person identifier</param>
        /// <param name="request">The person data</param>
        /// <returns>The updated person</returns>
        /// <response code="202">The person was successfully saved</response>
        /// <response code="400">The person data sent is invalid</response>
        /// <response code="404">The person was not found</response>
        [HttpPatch]
        [Route("{personId:long}")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Patch(int personId, [FromBody] UpdatePersonRequest request)
        {
            PersonResponse person = await personAppService.UpdatePerson(personId, request);

            return AcceptedAtRoute(
                routeName: "GetPerson",
                routeValues: new { personId = person.PersonId },
                value: person);
        }

        /// <summary>
        /// Delete a person
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/people/1
        ///
        /// </remarks>
        /// <param name="personId">The person identifier</param>
        /// <returns>The updated person</returns>
        /// <response code="202">The person was successfully deleted</response>
        /// <response code="404">The person was not found</response>
        [HttpDelete]
        [Route("{personId:long}")]
        [ProducesResponseType(typeof(PersonResponse), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int personId)
        {
            await personAppService.DeletePerson(personId);
            return Accepted();
        }
    }
}
