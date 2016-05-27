using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork;

namespace Aritter.Domain.SecurityModule.Services
{
    public sealed class AuthenticationService : DomainService, IAuthenticationService
    {
        public bool Authenticate(User user, string password)
        {
            if (user == null)
            {
                return false;
            }

            if (!user.ValidateCredentials(password))
            {
                return false;
            }

            return true;
        }
    }
}
