using System.Collections.Generic;

namespace Aritter.Application.DTO.SecurityModule
{
    public class AuthenticationDto
    {
        public bool IsAuthenticated { get; set; }
        public UserAccountDto User { get; set; }
        public ICollection<string> Errors { get; set; } = new List<string>();
    }
}
