using FoodlerRepository.Database.Repositories;
using FoodlerRepository.Entities;
using FoodlerRepository.Services.Interfaces;

namespace FoodlerRepository.Services
{
    public class FoodlerRecipeService : IFoodlerRecipeService
    {
        private readonly RecipeRepository recipeRepository;

        public FoodlerRecipeService(RecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }
        public void AddRecipe(Recipe recipe)
        {
            var recipes = recipeRepository.GetRecipes()
                                          .ToList();
            var recipeQuery = recipes.Find(r => r.Name == recipe.Name);
            if (recipeQuery == null)
            {
                recipeRepository.Insert(recipe);
                recipeRepository.Save();
            }
        }
    }
}
