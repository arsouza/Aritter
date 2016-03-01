using Aritter.Infra.CrossCutting.Security;
using System.Collections.Generic;

namespace Aritter.Application.DTO.Security
{
    public class PermissionDTO : DTO
    {
        public int FeatureId { get; set; }
        public Rule Rule { get; set; }
        public FeatureDTO Feature { get; set; }
        public ICollection<AuthorizationDTO> Authorizations { get; set; }
    }
}
