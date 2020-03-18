using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Http.Controllers.Requests;
using Ritter.Infra.Http.Controllers.Results;
using Ritter.Infra.Http.Extensions;
using Ritter.Infra.Http.Seedwork.Controllers;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;
using Ritter.Samples.Application.People;
using Ritter.Samples.Infra.Data.Query.Repositories.People;

namespace Ritter.Samples.Api.Controllers
{
    /// <summary>
    /// Everything about People
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResponse<PersonResponse>>> Get([FromQuery] PaginationRequest request)
        {
            return Paged(await personQueryRepository.FindAsync(request.ToPagination()));
        }

        [HttpGet("{personId:long}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonResponse>> GetById(long personId)
        {
            PersonResponse person = await personQueryRepository.FindAsync(personId);

            if (person is null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonResponse>> Post([FromBody] AddPersonRequest request)
        {
            PersonResponse person = await personAppService.AddPerson(request);

            return CreatedAtRoute(
                routeName: "GetById",
                routeValues: new { personId = person.PersonId },
                value: person);
        }

        [HttpPatch]
        [Route("{personId:long}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonResponse>> Patch(int personId, [FromBody] UpdatePersonRequest request)
        {
            PersonResponse person = await personAppService.UpdatePerson(personId, request);

            return AcceptedAtRoute(
                routeName: "GetById",
                routeValues: new { personId = person.PersonId },
                value: person);
        }

        [HttpDelete]
        [Route("{personId:long}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int personId)
        {
            await personAppService.DeletePerson(personId);
            return Accepted();
        }
    }
}
