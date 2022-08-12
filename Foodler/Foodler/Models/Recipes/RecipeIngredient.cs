using System;
using System.Collections.Generic;
using System.Text;

namespace Foodler.Models.Recipes
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
