using Foodler.Repository.Database.Context;
using Foodler.Repository.Entities;
using Foodler.Repository.Repositories.Bases;
using Foodler.Repository.Repositories.Interfaces;

namespace Foodler.Repository.Database.Repositories
{
    public class RecipeRepository : RepositoryBase<Recipe>
    {
        private FoodlerDatabaseContext context;

        public RecipeRepository(FoodlerDatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public override IQueryable<Recipe> Query()
        {
            return context.Recipes;
        }

    }
}
