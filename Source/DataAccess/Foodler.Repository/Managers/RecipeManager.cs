using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;

namespace Foodler.Repository.Managers
{
    public class RecipeManager : IEntityManager<Recipe>
    {
        public Recipe Create(string name)
        {
            return new Recipe
            {
                Name = name
            };
        }
    }
}
