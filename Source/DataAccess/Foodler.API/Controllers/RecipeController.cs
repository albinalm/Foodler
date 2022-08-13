using Foodler.Shared.Models.Recipes;
using Foodler.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace FoodlerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {


        private readonly ILogger<RecipeController> _logger;
        private readonly IFoodlerRecipeService foodlerRecipeService;

        public RecipeController(ILogger<RecipeController> logger, IFoodlerRecipeService foodlerRecipeService)
        {
            _logger = logger;
            this.foodlerRecipeService = foodlerRecipeService;
        }

        [HttpPost(Name = "AddRecipe")]
        public string Post(Ingredient ingredient)
        {
            //foreach (var recipe in recipes)
            //{
            //    foodlerRecipeService.AddRecipe(recipe);
            //}
            //return "lol";
            var fetchedRecipes = foodlerRecipeService.GetRecipesWithIngredient(ingredient);
            var message = "";
            foreach (var recipe in fetchedRecipes)
            {
                message += recipe.Name + Environment.NewLine;
            }
            return message;
        }


    }
}