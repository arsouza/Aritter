using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
    public class FeatureDTO : DTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ModuleId { get; set; }
        public ModuleDTO Module { get; set; }
        public ICollection<PermissionDTO> Permissions { get; set; }
    }
}
