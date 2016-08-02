using System;

namespace Aritter.Application.DTO.SecurityModule.Authentication
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public Guid UID { get; set; }
    }
}
