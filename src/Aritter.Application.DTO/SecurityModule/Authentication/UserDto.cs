using System;

namespace Aritter.Application.DTO.SecurityModule.Authentication
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public Guid Identity { get; set; }
    }
}
