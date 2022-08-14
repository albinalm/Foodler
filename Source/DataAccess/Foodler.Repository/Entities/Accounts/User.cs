using Foodler.Repository.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Entities.Accounts
{
    public class User : EntityBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        protected override IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                yield return new ValidationResult(
                    "The property 'Email' cannot be null or contain only whitespaces",
                    new[] { nameof(Email) });
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                yield return new ValidationResult(
                    "The property 'Password' cannot be null or contain only whitespaces",
                    new[] { nameof(Password) });
            }
        }
    }
}
