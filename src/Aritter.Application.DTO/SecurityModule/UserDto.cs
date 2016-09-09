using System;

namespace Aritter.Application.DTO.SecurityModule
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid UID { get; set; }
    }
}
