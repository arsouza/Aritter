using System.Collections.Generic;

namespace Aritter.Application.DTO
{
    public class AuthorizationDto
    {
        public UserDto User { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<string> Permissions { get; set; }
    }
}
