using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Foodler.Models.Recipes
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //  public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
