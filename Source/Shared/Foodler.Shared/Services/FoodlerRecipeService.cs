using AutoMapper;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Repositories.Interfaces;
using Foodler.Shared.Services.Interfaces;
using RecipeEntities = Foodler.Repository.Entities.Recipes;
using RecipeModels = Foodler.Shared.Models.Recipes;

namespace Foodler.Shared.Services
{
    public class FoodlerRecipeService : IFoodlerRecipeService
    {
        private readonly IRepository<RecipeEntities.Recipe> recipeRepository;
        private readonly IRepository<RecipeEntities.Ingredient> ingredientRepository;
        private readonly IEntityManager<RecipeEntities.Recipe> recipeManager;
        private readonly IMapper mapper;

        public FoodlerRecipeService(IRepository<RecipeEntities.Recipe> recipeRepository, IRepository<RecipeEntities.Ingredient> ingredientRepository, IEntityManager<RecipeEntities.Recipe> recipeManager, IMapper mapper)
        {
            this.recipeRepository = recipeRepository;
            this.ingredientRepository = ingredientRepository;
            this.recipeManager = recipeManager;
            this.mapper = mapper;
        }
        public void AddRecipe(RecipeModels.Recipe recipe)
        {
            var newrecipe = mapper.Map<RecipeEntities.Recipe>(recipe);

            recipeRepository.Insert(newrecipe);
            recipeRepository.Save();
        }
        public IEnumerable<RecipeModels.Recipe> GetRecipesWithIngredient(RecipeModels.Ingredient ingredient)
        {
            var recipes = recipeRepository.Query()
                                        .ToList();

            var filteredRecipes = new List<RecipeEntities.Recipe>();
            foreach (var recipe in recipes)
            {
                foreach (var recipeIngredient in recipe.Ingredients)
                {
                    if (recipeIngredient.Name == ingredient.Name)
                    {
                        filteredRecipes.Add(recipe);
                    }
                }
            }
            var result = new List<RecipeModels.Recipe>();
            foreach (var recipe in filteredRecipes)
            {
                result.Add(mapper.Map<RecipeModels.Recipe>(recipe));
            }
            return result;

        }
    }
}
