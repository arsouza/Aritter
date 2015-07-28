using System.Web.Http;

namespace Aritter.API.Controllers
{
	[Authorize]
	public class ValuesController : BaseController
	{
		// GET api/values
		public IHttpActionResult Get()
		{
			return Ok(new[] { "value1", "value2" });
		}

		// GET api/values/5
		public IHttpActionResult Get(int id)
		{
			return Ok("value");
		}

		// POST api/values
		public void Post([FromBody]string value)
		{
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
		}
	}
}
