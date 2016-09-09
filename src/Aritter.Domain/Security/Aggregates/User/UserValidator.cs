using Aritter.Domain.Seedwork.Rules.Validation;
using Aritter.Domain.Seedwork.Rules.Validation.Common;

namespace Aritter.Domain.Security.Aggregates.Validators
{
    public sealed class UserValidator : EntityValidator<User>
    {
        public UserValidator()
        {
            AddValidation("UsernameRequired", new HasRequiredRule<User>(p => p.Username, "Username is required"));
            AddValidation("PasswordRequired", new HasRequiredRule<User>(p => p.Password, "Password is required"));
            AddValidation("EmailRequired", new HasRequiredRule<User>(p => p.Email, "Email is required"));
        }
    }
}
