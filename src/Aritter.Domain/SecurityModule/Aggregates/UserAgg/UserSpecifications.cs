using Aritter.Domain.Seedwork.Specifications;
using System;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg
{
    public static class UserSpecifications
    {
        public static ISpecification<User> FindEnabledByUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            return new DirectSpecification<User>(u => u.IsEnabled && u.UserName == userName);
        }
    }
}
