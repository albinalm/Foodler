using FoodlerRepository.Database.Context;
using FoodlerRepository.Entities;

namespace FoodlerRepository.Database.Repositories
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
    }
}
