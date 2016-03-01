using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
    public class MenuDTO : DTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public int ModuleId { get; set; }
        public ModuleDTO Module { get; set; }
        public MenuDTO Parent { get; set; }
        public ICollection<RoleMenuDTO> Roles { get; set; }
        public ICollection<MenuDTO> Children { get; set; }
    }
}
