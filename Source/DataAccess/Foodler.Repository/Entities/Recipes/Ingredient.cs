using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Entities.Recipes
{
    public class Ingredient : EntityBase, IIngredient
    {
        public long Quantity { get; set; }
        public Measurment Measurment { get; set; }
        public IngredientCategory Category { get; set; }

        public IIngredient SetCategory(IngredientCategory category)
        {
            this.Category = category;
            return this;
        }

        public IIngredient SetMeasurment(Measurment measurment)
        {
            this.Measurment = measurment;
            return this;
        }

        public IIngredient SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public IIngredient SetQuantity(long quantity)
        {
            this.Quantity = quantity;
            return this;
        }

        protected override IEnumerable<ValidationResult> CustomValidation(ValidationContext validationContext)
        {
            if (Quantity == 0)
            {
                yield return new ValidationResult(
                    "The property 'Quantity' must have a value greater than 0",
                    new[] { nameof(Quantity) });
            }
            if (Measurment == null)
            {
                yield return new ValidationResult(
                   "The property 'Measurment' cannot be null",
                   new[] { nameof(Measurment) });
            }
            if (Category == null)
            {
                yield return new ValidationResult(
                 "The property 'Ingredient' category cannot be null",
                 new[] { nameof(Category) });
            }
        }
    }
}
