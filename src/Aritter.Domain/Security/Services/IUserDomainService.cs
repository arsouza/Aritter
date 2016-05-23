using Aritter.Domain.Security.Aggregates.Users;
using Aritter.Domain.Seedwork;

namespace Aritter.Domain.Security.Services
{
    public interface IUserDomainService : IDomainService
    {
        User Authenticate(string userName, string password);
    }
}
