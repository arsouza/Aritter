using System.Collections.Generic;

namespace Aritter.Application.DTO.SecurityModule.Authentication
{
    public class AuthenticationDto
    {
        public UserAccountDto User { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<string> Permissions { get; set; }
    }
}
