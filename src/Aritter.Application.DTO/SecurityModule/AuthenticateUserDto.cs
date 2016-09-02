using System;

namespace Aritter.Application.DTO.SecurityModule
{
    public class AuthenticateUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
