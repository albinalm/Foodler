using Foodler.Repository.Entities.Bases.Interfaces;
using Foodler.Repository.Entities.Security;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Entities.Recipes.Interfaces
{
    public interface IRecipe : IEntityBase
    {
        IEnumerable<Ingredient> Ingredients { get; set; }
        string Instructions { get; set; }
        User Author { get; set; }

        IRecipe SetAuthor(User author);
        IRecipe SetIngredients(IEnumerable<Ingredient> ingredients);
        IRecipe SetInstructions(string instructions);
        IRecipe SetName(string name);
    }
}
