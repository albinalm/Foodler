using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;

namespace Foodler.Repository.Entities.Recipes
{
    public class IngredientCategory : EntityBase, IIngredientCategory
    {
        public void SetName(string name)
        {
            this.Name = name;
        }
    }
}
