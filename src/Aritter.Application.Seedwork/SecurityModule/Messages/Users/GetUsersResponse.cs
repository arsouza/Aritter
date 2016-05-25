using Aritter.Application.DTO.Security.Users;
using System.Collections.Generic;

namespace Aritter.Application.Seedwork.SecurityModule.Messages.Users
{
    public class GetUsersResponse
    {
        public bool Success { get; set; }
        public ICollection<string> Messages { get; set; }
        public ICollection<GetUserDto> Users { get; set; }
    }
}
