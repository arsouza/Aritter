using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
	public class ModuleDTO : DTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<ResourceDTO> Resources { get; set; }
		public virtual ICollection<MenuDTO> Menus { get; set; }
		public virtual ICollection<PermissionDTO> Permissions { get; set; }
	}
}
