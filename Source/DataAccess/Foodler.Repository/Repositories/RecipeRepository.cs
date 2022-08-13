using Foodler.Repository.Database.Context;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Repositories.Bases;
using Foodler.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Foodler.Repository.Repositories
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
            return context.Recipes.Include(r => r.Ingredients);
        }
    }
}
