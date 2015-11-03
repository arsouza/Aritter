using Aritter.Domain.SecurityModule.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aritter.Domain.SecurityModule.Services
{
    public class AuthenticationDomainService : DomainService, IAuthenticationDomainService
    {
        private readonly IUserRoleRepository userRoleRepository;

        public AuthenticationDomainService(IUserRoleRepository userRoleRepository)
            : base()
        {
            this.userRoleRepository = userRoleRepository;
        }

        public virtual async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType)
        {
            var roles = userRoleRepository
                .GetRolesByUserId(user.Id)
                .Select(x => new { x.Role.Name })
                .ToList();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

            var identity = new ClaimsIdentity(claims, authenticationType);

            return await Task.FromResult(identity);
        }
    }
}
