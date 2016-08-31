using System.Collections.Generic;

namespace Aritter.Application.DTO.SecurityModule
{
    public class PermissionDto
    {
        public string Client { get; set; }

        public string Operation { get; set; }

        public string Resource { get; set; }

        public ICollection<AuthorizationDto> Authorizations { get; set; }
    }
}
