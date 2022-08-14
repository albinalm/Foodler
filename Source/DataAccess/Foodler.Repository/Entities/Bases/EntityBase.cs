using Foodler.Repository.Entities.Recipes.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Bases
{
    public class EntityBase : IValidatableObject
    {
        public int Id { get; protected set; }

        public string Name { get; set; }

        protected virtual IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext) => Enumerable.Empty<ValidationResult>();
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult(
                    "The property 'Name' cannot be null or contain only whitespaces",
                    new[] { nameof(Name) });

            foreach (var validationResult in CustomValidation(validationContext))
                yield return validationResult;

        }
    }
}
