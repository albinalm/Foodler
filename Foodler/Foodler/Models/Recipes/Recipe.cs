using Newtonsoft.Json;
using System;

namespace Foodler.Models.Recipes
{
    public class Recipe
    {
        [JsonProperty("title")]
        public string Name { get; set; }
        public DayOfWeek Weekday { get; set; }
        public int Servings { get; set; }
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        [JsonProperty("image")]
        public string ImageUrl { get; set; }
        [JsonProperty("extendedIngredients")]
        public Ingredient[] Ingredients { get; set; }
        public string Instructions { get; set; }
        public string[] DishTypes { get; set; }
    }
}
