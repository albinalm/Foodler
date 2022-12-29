using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;

namespace Foodler.Repository.Entities.Recipes;

public class RecipeImage : EntityBase, IRecipeImage
{
    public byte[] ImageBytes { get; set; }
    public RecipeImage(string name) : base(name)
    {
    }
}