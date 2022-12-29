using System.ComponentModel.DataAnnotations;
using Foodler.Abstractions.Models.Recipes;
using Foodler.Abstractions.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Foodler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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
        public IActionResult AddRecipe(Recipe recipe)
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
        }

        [HttpPost(Name = "RemoveRecipe")]
        public IActionResult RemoveRecipe(Recipe recipe)
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
        }

    }
}