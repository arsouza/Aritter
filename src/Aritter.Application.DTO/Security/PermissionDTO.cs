using Aritter.Infra.Crosscutting.Security;

namespace Aritter.Application.DTO.Security
{
    public class PermissionDTO : DTO
    {
        public Rule Rule { get; set; }
        public virtual ResourceDTO Resource { get; set; }
        public virtual AuthorizationDTO Authorization { get; set; }
    }
}
