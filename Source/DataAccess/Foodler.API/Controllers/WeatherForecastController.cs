using Foodler.Repository.Database.Repositories;
using Foodler.Repository.Entities;
using Foodler.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models = Foodler.Shared.Models;
namespace FoodlerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFoodlerRecipeService foodlerRecipeService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFoodlerRecipeService foodlerRecipeService)
        {
            _logger = logger;
            this.foodlerRecipeService = foodlerRecipeService;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Post(Models.Recipe recipe, string name)
        {

            foodlerRecipeService.AddRecipe(recipe);

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


    }
}