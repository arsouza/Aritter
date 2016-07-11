using Aritter.Application.DTO.SecurityModule.Authentication;
using Aritter.Application.DTO.SecurityModule.Users;
using Aritter.Infra.Crosscutting.Security;
using Aritter.Infra.Web.Security;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aritter.API.Controllers
{
    [RoutePrefix("api/v1")]
    public class UsersController : DefaultApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        [Route("users/{id:int}/profile")]
        [Authorization("Users", Rule.Get)]
        public async Task<string> GetProfile(int id)
        {
            return await Task.FromResult("value");
        }

        [HttpPost]
        [Route("users")]
        [Authorization("Users", Rule.Post)]
        public async Task<UserDto> Post([FromBody]AddUserDto user)
        {
            return await Task.FromResult(new UserDto
            {
                FirstName = user.FirstName,
                Username = user.Username,
                LastName = user.LastName,
                Identity = Guid.NewGuid(),
                IsEnabled = true,
                Id = 23,
                Email = user.Email
            });
        }

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