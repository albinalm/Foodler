using Foodler.Repository.Database.Context;
using Foodler.Repository.Entities;
using Foodler.Repository.Repositories.Bases;

namespace Foodler.Repository.Database.Repositories
{
    public class IngredientRepository : RepositoryBase<Ingredient>
    {
        private FoodlerDatabaseContext context;

        public IngredientRepository(FoodlerDatabaseContext context) : base(context)
        {
            this.context = context;
        }
        public IQueryable<Ingredient> GetIngredients()
        {
            return context.Ingredients;
        }

        public override IQueryable<Ingredient> Query()
        {
            return context.Ingredients;
        }
    }
}
