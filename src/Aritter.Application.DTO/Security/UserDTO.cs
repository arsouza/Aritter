using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
    public class UserDTO : DTO
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool MustChangePassword { get; set; }
        public bool IsActive { get; set; }
        public ICollection<AuthenticationDTO> Authentications { get; set; }
        public ICollection<UserPasswordDTO> PasswordHistory { get; set; }
        public ICollection<UserRoleDTO> Roles { get; set; }
    }
}
