using Aritter.Application.DTO.Security.Users;
using System.Collections.Generic;

namespace Aritter.Application.Seedwork.SecurityModule.Messages.Users
{
    public class GetUserResponse
    {
        public bool Success { get; set; }
        public ICollection<string> Messages { get; set; }
        public GetUserDto User { get; set; }
    }
}
