using Aritter.Domain.SecurityModule.Aggregates.UserAgg.Specs;
using Aritter.Domain.Seedwork.Rules.Validation;

namespace Aritter.Domain.SecurityModule.Aggregates.UserAgg.Validators
{
    public sealed class UserValidator : EntityValidator<User>
    {
        public UserValidator()
        {
            AddValidation("UserNameNotNull", new ValidationRule<User>(new UserHasValidUsernameSpec(), "UserName cannot be null.", nameof(User.Username)));
        }
    }
}
