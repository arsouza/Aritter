using Aritter.Domain.SecurityModule.Aggregates.Specs;
using Aritter.Domain.Seedwork.Rules.Validation;
using Aritter.Domain.Seedwork.Rules.Validation.Common;

namespace Aritter.Domain.SecurityModule.Aggregates.Validators
{
    public sealed class UserAccountValidator : EntityValidator<UserAccount>
    {
        public ValidationResult ValidateCredentials(UserAccount account, string password)
        {
            RemoveValidations();
            AddValidation("ValidCredentials", new ValidationRule<UserAccount>(UserAccountSpecs.HasValidCredentials(password), "Invalid username or password."));

            return Validate(account);
        }

        public ValidationResult ValidateAccount(UserAccount account)
        {
            RemoveValidations();
            AddValidation("UsernameRequired", new HasRequiredRule<UserAccount>(p => p.Username, "Username is required"));
            AddValidation("PasswordRequired", new HasRequiredRule<UserAccount>(p => p.Password, "Password is required"));
            AddValidation("EmailRequired", new HasRequiredRule<UserAccount>(p => p.Email, "Email is required"));

            return Validate(account);
        }
    }
}
