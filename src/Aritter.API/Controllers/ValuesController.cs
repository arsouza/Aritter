﻿using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [Authorize]
    public class ValuesController : DefaultApiController
    {
        // GET api/values
        public async Task<IHttpActionResult> Get()
        {
            return Ok(DateTime.Now);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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