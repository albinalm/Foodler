using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Security.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Entities.Security
{
    public class User : EntityBase, IUser
    {
        public User(string name) : base(name)
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public IUser SetName(string name)
        {
            this.Name = name;
            return this;
        }
        public IUser SetEmail(string email)
        {
            //TODO: Add hashing algorithm
            this.Email = email;
            return this;
        }
        public IUser SetPassword(string password)
        {
            //TODO: Placeholder. Add security service to set hashed passwords on entity
            this.Password = password;
            return this;
        }
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
