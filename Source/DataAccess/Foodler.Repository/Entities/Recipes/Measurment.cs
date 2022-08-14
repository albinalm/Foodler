using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Entities.Recipes
{
    public class Measurment : EntityBase, IMeasurment
    {
        public string ShortName { get; set; }

        public IMeasurment SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public IMeasurment SetShortName(string shortName)
        {
            this.ShortName = shortName;
            return this;
        }

        protected override IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(ShortName))
            {
                yield return new ValidationResult(
                    "The property 'ShortName' cannot be null or contain only whitespaces",
                    new[] { nameof(ShortName) });
            }
        }
    }
}
