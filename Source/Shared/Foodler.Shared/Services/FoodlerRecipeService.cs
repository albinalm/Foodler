using AutoMapper;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Repositories.Interfaces;
using Foodler.Shared.Services.Interfaces;
using System.Linq;
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
            var entity = mapper.Map<RecipeEntities.Recipe>(recipe);

            recipeRepository.Insert(entity);
            recipeRepository.Save();
        }

        public IEnumerable<RecipeModels.Recipe> GetRecipesContainingIngredient(string ingredientName)
        {
            var ingredients = ingredientRepository.FindByName(ingredientName);
            var recipes = recipeRepository.Query();

            foreach (var ingredient in ingredients)
                yield return mapper.Map<RecipeModels.Recipe>
                                    (recipes.First(r => r.Ingredients.Contains(ingredient)));
        }
        public void DeleteRecipe(RecipeModels.Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe), "Input parameter recipe cannot be null");

            var entity = recipeRepository.FindByName(recipe.Name).FirstOrDefault();
            recipeRepository.Delete(entity);
            recipeRepository.Save();
        }
    }
}
