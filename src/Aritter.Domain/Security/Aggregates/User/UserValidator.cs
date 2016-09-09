using Aritter.Domain.Security.Aggregates.Specs;
using Aritter.Domain.Seedwork.Rules.Validation;
using Aritter.Domain.Seedwork.Rules.Validation.Common;

namespace Aritter.Domain.Security.Aggregates.Validators
{
    public sealed class UserValidator : EntityValidator<User>
    {
        public ValidationResult ValidateCredentials(User user, string password)
        {
            RemoveValidations();
            AddValidation("ValidCredentials", new ValidationRule<User>(UserSpecs.HasValidPassword(password), "Invalid username or password."));

            return Validate(user);
        }

        public ValidationResult ValidateUser(User user)
        {
            RemoveValidations();
            AddValidation("UsernameRequired", new HasRequiredRule<User>(p => p.Username, "Username is required"));
            AddValidation("PasswordRequired", new HasRequiredRule<User>(p => p.Password, "Password is required"));
            AddValidation("EmailRequired", new HasRequiredRule<User>(p => p.Email, "Email is required"));

            return Validate(user);
        }
    }
}
