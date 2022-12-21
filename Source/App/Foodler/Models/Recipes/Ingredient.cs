using Foodler.Models.Measurments;
using System.Collections.Generic;

namespace Foodler.Models.Recipes
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
