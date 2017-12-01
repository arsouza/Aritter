using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ritter.Samples.Application;
using Ritter.Samples.Web.Core;

namespace Ritter.Samples.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private AppTenant tenant;

        public ValuesController(AppTenant tenant)
        {
            this.tenant = tenant;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return tenant.Name;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        { }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        { }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        { }
    }
}