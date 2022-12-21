using Foodler.Abstractions.Models.Recipes;

namespace Foodler.Abstractions.Services.Interfaces
{
    public interface IFoodlerRecipeService
    {
        void AddRecipe(Recipe recipe);
        IEnumerable<Recipe> GetRecipesContainingIngredient(string ingredientName);
    }
}
