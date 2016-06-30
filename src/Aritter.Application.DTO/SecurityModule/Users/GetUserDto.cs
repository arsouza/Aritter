using System;

namespace Aritter.Application.DTO.SecurityModule.Users
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool MustChangePassword { get; set; }
        public bool Enabled { get; set; }
        public Guid Identity { get; set; }
    }
}
