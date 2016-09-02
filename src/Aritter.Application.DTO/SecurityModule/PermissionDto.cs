using System.Collections.Generic;

namespace Aritter.Application.DTO.SecurityModule
{
    public class PermissionDto
    {
        public string Application { get; set; }

        public string Rule { get; set; }

        public string Resource { get; set; }

        public ICollection<AuthorizationDto> Authorizations { get; set; }
    }
}
