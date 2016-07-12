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
        public UsersController()
        {

        }

        [HttpGet]
        [Route("users/{id:int}")]
        [Authorization("Users", Rule.Get)]
        public async Task<IHttpActionResult> GetById(int id)
        {
            return await SuccessAsync(new UserDto());
        }

        [HttpGet]
        [Route("users/{username}")]
        [Authorization("Users", Rule.Get)]
        public async Task<IHttpActionResult> GetByUsername(string username)
        {
            return await SuccessAsync(new UserDto());
        }

        [HttpGet]
        [Route("users/{id:int}/profile")]
        [Authorization("Users", Rule.Get)]
        public async Task<IHttpActionResult> GetProfile(int id)
        {
            return await SuccessAsync("profile");
        }

        [HttpPost]
        [Route("users")]
        [Authorization("Users", Rule.Post)]
        public async Task<IHttpActionResult> Post([FromBody]AddUserDto user)
        {
            return await SuccessAsync(new UserDto
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