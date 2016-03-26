using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
	public class ResourceDTO : DTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ModuleDTO Module { get; set; }
		public virtual ICollection<PermissionDTO> Permissions { get; set; }
	}
}
