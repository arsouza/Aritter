using System.Collections.Generic;

namespace Aritter.Application.DTO.SecurityModule
{
    public class AuthorizationDto
    {
        public string Operation { get; set; }
        public string Resource { get; set; }
        public string Client { get; set; }
        public Dictionary<string, string> Authorizations { get; set; }
    }
}
