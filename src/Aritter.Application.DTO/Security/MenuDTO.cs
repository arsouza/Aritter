using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
	public class MenuDTO : DTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public string Url { get; set; }
		public virtual ModuleDTO Module { get; set; }
		public virtual MenuDTO Parent { get; set; }
		public virtual ICollection<MenuDTO> Children { get; set; }
	}
}
