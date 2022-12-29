using Foodler.Repository.Context;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Repositories.Bases;

namespace Foodler.Repository.Repositories
{
    public class IngredientCategoryRepository : RepositoryBase<IngredientCategory>
    {
        private readonly FoodlerDatabaseContext context;

        public IngredientCategoryRepository(FoodlerDatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public override IQueryable<IngredientCategory> Query()
        {
            return context.IngredientCategories;
        }
    }
}
