using System;

namespace Aritter.Application.DTO.SecurityModule.Authentication
{
    public class UserAccountDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public Guid UID { get; set; }

        public string FirstName()
        {
            return Name.Split(' ')[0];
        }
    }
}
