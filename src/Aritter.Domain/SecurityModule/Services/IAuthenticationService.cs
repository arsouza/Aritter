using Aritter.Domain.SecurityModule.Aggregates.UserAgg;
using Aritter.Domain.Seedwork.Services;

namespace Aritter.Domain.SecurityModule.Services
{
    public interface IAuthenticationService : IDomainService
    {
        bool Authenticate(User user, string password);
    }
}
