using System;

namespace Aritter.Application.DTO.Security
{
    public class AuthenticationDTO : DTO
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public AuthenticationState State { get; set; }
        public UserDTO User { get; set; }
    }
}
