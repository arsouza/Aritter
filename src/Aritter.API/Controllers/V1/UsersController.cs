using Aritter.Infra.Crosscutting.Security;
using Aritter.Infra.Web.Security;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [RoutePrefix("api/v1/users")]
    public class UsersController : DefaultApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        [Authorization("Users", Rule.Get)]
        [Route("{id:int}/profile")]
        public async Task<string> GetProfile(int id)
        {
            return await Task.FromResult("value");
        }

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}