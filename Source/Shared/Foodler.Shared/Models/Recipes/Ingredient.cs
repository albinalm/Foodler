using Foodler.Shared.Models.Bases;

namespace Foodler.Shared.Models.Recipes
{
    public class Ingredient : ModelBase
    {
        public long Quantity { get; set; }
        public Measurment Measurment { get; set; }
        public IngredientCategory Category { get; set; }
    }
}
