using Foodler.Repository.Entities.Recipes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Bases
{
    public abstract class EntityBase : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        protected abstract IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext);
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult(
                    "Name cannot be null or contain only whitespaces",
                    new[] { nameof(Name) });
            }
            CustomValidation(validationContext);
        }
    }
}
