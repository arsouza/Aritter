using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aritter.Security.Application.Services.Users;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUserAppService userAppService;

        public ValuesController(IUserAppService userAppService)
        {
            Check.IsNotNull(userAppService, nameof(userAppService));

            this.userAppService = userAppService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Task.FromResult(new string[] { "value1", "value2" }));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Task.FromResult("value"));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]string value)
        {
            return Ok(await Task.FromResult<object>(null));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]string value)
        {
            return Ok(await Task.FromResult<object>(null));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Task.FromResult<object>(null));
        }
    }
}