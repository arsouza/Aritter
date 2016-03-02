using Aritter.API.Core.Attributes;
using Aritter.Application.DTO.Security;
using Aritter.Infra.CrossCutting.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    public class ValuesController : DefaultApiController
    {
        [Authorization("Feat1", Rule.Get)]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await Task.FromResult(new UserDTO { UserName = "Teste" }));
        }
    }
}
