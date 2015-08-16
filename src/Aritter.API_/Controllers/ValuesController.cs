using Aritter.API_.Attributes;
using System.Linq;
using System.Web.Http;

namespace Aritter.API_.Controllers
{
	[Authorization]
	[RoutePrefix("api/values")]
	public class ValuesController : ApiController
	{
		string[] values = new[] { "value1", "value2", "value3", "value4", "value5", "value6", "value7", "value8", "value9", "value10" };

		// GET api/values
		public IHttpActionResult Get()
		{
			return Ok(values);
		}

		// GET api/values/5
		public IHttpActionResult Get(int id)
		{
			return Ok(values.FirstOrDefault(p => p.Contains(id.ToString())));
		}

		// GET api/values/search
		[HttpGet, Route("search")]
		public IHttpActionResult Search(string q)
		{
			return Ok(values.Where(p => p.Contains(q)));
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
