using Foodler.Repository.Database.Context;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Repositories.Bases;

namespace Foodler.Repository.Repositories
{
    public class IngredientRepository : RepositoryBase<Ingredient>
    {
        private FoodlerDatabaseContext context;

        public IngredientRepository(FoodlerDatabaseContext context) : base(context)
        {
            this.context = context;
        }

        public override IQueryable<Ingredient> FindByName(string name)
        {
            return context.Ingredients.Where(i => i.Name == name);
        }

        public override IQueryable<Ingredient> Query()
        {
            return context.Ingredients;
        }
    }
}
