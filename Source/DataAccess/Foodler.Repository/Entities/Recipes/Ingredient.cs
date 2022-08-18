using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Entities.Recipes
{
    public class Ingredient : EntityBase, IIngredient
    {
        public Ingredient(string name) : base(name)
        {
        }

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

        #region Overloads
        public IIngredient SetMeasurment(IMeasurment measurment)
        {
            return SetMeasurment((Measurment)measurment);
        }
        public IIngredient SetCategory(IIngredientCategory category)
        {
            return SetCategory((IngredientCategory)category);
        }
        #endregion

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
                 "The property 'Category' category cannot be null",
                 new[] { nameof(Category) });
            }
        }
    }
}
