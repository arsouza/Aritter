using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ritter.Infra.Http.Controllers;
using Ritter.Infra.Http.Controllers.Requests;
using Ritter.Infra.Http.Controllers.Results;
using Ritter.Infra.Http.Extensions;
using Ritter.Samples.Application.DTO.People.Requests;
using Ritter.Samples.Application.DTO.People.Responses;
using Ritter.Samples.Application.People;
using Ritter.Samples.Infra.Data.Query.Repositories.People;

namespace Ritter.Samples.Api.Controllers.V1
{
    /// <summary>
    /// Everything about People
    /// </summary>
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
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

        [HttpGet("{uid:Guid}", Name = nameof(GetByUid))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonResponse>> GetByUid(Guid uid)
        {
            PersonResponse person = await personQueryRepository.FindAsync(uid);

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
                routeName: nameof(GetByUid),
                routeValues: new { uid = person.PersonId },
                value: person);
        }

        [HttpPatch]
        [Route("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonResponse>> Patch(Guid uid, [FromBody] UpdatePersonRequest request)
        {
            PersonResponse person = await personAppService.UpdatePerson(uid, request);

            return AcceptedAtRoute(
                routeName: nameof(GetByUid),
                routeValues: new { uid = person.PersonId },
                value: person);
        }

        [HttpDelete]
        [Route("{uid:Guid}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid uid)
        {
            await personAppService.DeletePerson(uid);
            return Accepted();
        }
    }
}
