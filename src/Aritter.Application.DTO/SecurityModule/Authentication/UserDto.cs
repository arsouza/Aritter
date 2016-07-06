using System;

namespace Aritter.Application.DTO.SecurityModule.Authentication
{
    public class UserDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Identity { get; set; }
    }
}
