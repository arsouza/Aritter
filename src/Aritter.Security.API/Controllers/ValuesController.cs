using Aritter.Infra.Crosscutting.Exceptions;
using Aritter.Security.Application.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aritter.Security.API.Controllers
{
    /// <summary>
    /// Valores
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUserAppService userAppService;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="userAppService"></param>
        public ValuesController(IUserAppService userAppService)
        {
            Check.IsNotNull(userAppService, nameof(userAppService));

            this.userAppService = userAppService;
        }

        // GET api/values
        /// <summary>
        /// Retorna uma lista de strings
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna a lista de strings</response>
        /// <response code="401">Se o usuário não estiver autenticado</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Get()
        {
            userAppService.Void();
            return Ok(await Task.FromResult(new string[] { "value1", "value2" }));
        }

        /// <summary>
        /// Retorna um valor específico
        /// </summary>
        /// <param name="id">id do valor</param>
        /// <returns></returns>
        /// <response code="200">Retorna o valor</response>
        /// <response code="401">Se o usuário não estiver autenticado</response>
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string[]), 200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Task.FromResult("value"));
        }
    }
}
