using Foodler.Repository.Entities.Bases.Interfaces;
using Foodler.Repository.Entities.Recipes.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Bases
{
    [Index(nameof(Name), IsUnique = true)]
    public class EntityBase : IValidatableObject, IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public EntityBase(string name)
        {
            Name = name;
        }

        protected virtual IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext) => Enumerable.Empty<ValidationResult>();
        public IEnumerable<Valida4tionResult> Validate(ValidationContext validationContext)
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
