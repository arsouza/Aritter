using System.Collections.Generic;
using System.Linq;

namespace Aritter.Application.DTO.Security
{
    public class RoleDTO : DTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }
        public ModuleDTO Module { get; set; }
        public ICollection<UserRoleDTO> UserRoles { get; set; }
        public ICollection<RoleMenuDTO> Menus { get; set; }
        public ICollection<AuthorizationDTO> Authorizations { get; set; }
    }
}
