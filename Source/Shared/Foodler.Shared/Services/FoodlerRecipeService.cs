using Foodler.Repository.Database.Repositories;
using Entities = Foodler.Repository.Entities;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Shared.Services.Interfaces;
using Foodler.Repository.Repositories.Interfaces;
namespace Foodler.Shared.Services
{
    public class FoodlerRecipeService : IFoodlerRecipeService
    {
        private readonly IRepository<Entities.Recipe> recipeRepository;
        private readonly IRecipeManager recipeManager;

        public FoodlerRecipeService(IRepository<Entities.Recipe> recipeRepository, IRecipeManager recipeManager)
        {
            this.recipeRepository = recipeRepository;
            this.recipeManager = recipeManager;
        }
        public void AddRecipe(Models.Recipe recipe)
        {
            var recipes = recipeRepository.Query()
                                          .ToList();
            var recipeQuery = recipes.Find(r => r.Name == recipe.Name);
            if (recipeQuery == null)
            {
                var recipeEntity = recipeManager.Create();
                recipeManager.SetRecipeName(ref recipeEntity, recipe.Name);
                recipeRepository.Insert(recipeEntity);
                recipeRepository.Save();
            }
        }

    }
}
