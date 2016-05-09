using Aritter.Domain.Security.Aggregates;
using Aritter.Domain.Security.Aggregates.Users;
using Aritter.Domain.Seedwork.Services;

namespace Aritter.Domain.Security.Services
{
    public interface IUserDomainService : IDomainService
    {
        User Authenticate(string userName, string password);
    }
}
