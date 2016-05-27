using Aritter.Domain.Seedwork.Specifications;
using Aritter.Infra.Crosscutting.Exceptions;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public static class UserSpecifications
    {
        public static ISpecification<User> FindEnabledByUserName(string userName)
        {
            ThrowHelper.ThrowArgumentNullException(string.IsNullOrEmpty(userName), nameof(userName));
            return new DirectSpecification<User>(u => u.IsEnabled && u.UserName == userName);
        }

        public static ISpecification<User> FindEnabledById(int id)
        {
            ThrowHelper.ThrowArgumentNullException(default(int) == id, nameof(id));
            return new DirectSpecification<User>(u => u.IsEnabled && u.Id == id);
        }
    }
}
