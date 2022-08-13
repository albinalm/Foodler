using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;

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
    }
}
