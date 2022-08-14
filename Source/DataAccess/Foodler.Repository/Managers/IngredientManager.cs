using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;

namespace Foodler.Repository.Managers
{
    public class IngredientManager : IEntityManager<Ingredient>
    {
        public Ingredient Create(string name)
        {
            return new Ingredient
            {
                Name = name
            };
        }
    }
}
