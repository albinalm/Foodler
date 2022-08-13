using FoodlerRepository.Database.Context;
using FoodlerRepository.Entities;

namespace FoodlerRepository.Database.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe>
    {
        private FoodlerDatabaseContext context;

        public RecipeRepository(FoodlerDatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public IQueryable<Recipe> GetRecipes()
        {
            return context.Recipes;
        }
    }
}
