using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
    public class ModuleDTO : DTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RoleDTO> Roles { get; set; }
        public ICollection<FeatureDTO> Features { get; set; }
        public ICollection<MenuDTO> Menus { get; set; }
    }
}
