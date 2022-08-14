using Foodler.Shared.Models.Recipes;
using Foodler.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public IActionResult Post(Recipe recipe)
        {
            try
            {
                foodlerRecipeService.AddRecipe(recipe);
                return Ok(recipe);
            }
            catch (ValidationException validationException)
            {
                return BadRequest(validationException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            //foreach (var recipe in recipes)
            //{
            //    foodlerRecipeService.AddRecipe(recipe);
            //}
            //return "lol";
            //var fetchedRecipes = foodlerRecipeService.GetRecipesWithIngredient(ingredient);
            //var message = "";
            //foreach (var recipe in fetchedRecipes)
            //{
            //    message += recipe.Name + Environment.NewLine;
            //}
            //return message;
        }


    }
}