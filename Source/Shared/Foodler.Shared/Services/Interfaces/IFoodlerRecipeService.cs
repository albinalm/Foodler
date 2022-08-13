using Foodler.Shared.Models.Recipes;

namespace Foodler.Shared.Services.Interfaces
{
    public interface IFoodlerRecipeService
    {
        void AddRecipe(Recipe recipe);
        IEnumerable<Recipe> GetRecipesWithIngredient(Ingredient ingredient);
    }
}
