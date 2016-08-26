using System.Collections.Generic;

namespace Aritter.Application.DTO.SecurityModule.Authentication
{
    public class AuthorizationDto
    {
        public string Operation { get; set; }
        public string Resource { get; set; }
        public string Application { get; set; }
        public Dictionary<string, string> Authorizations { get; set; }
    }
}
