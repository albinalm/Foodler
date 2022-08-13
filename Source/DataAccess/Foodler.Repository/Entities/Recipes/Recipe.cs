using Foodler.Repository.Entities.Accounts;
using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes.Interfaces;

namespace Foodler.Repository.Entities.Recipes
{
    public class Recipe : EntityBase, IRecipe
    {
        public virtual IEnumerable<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public User Author { get; set; }

        public IRecipe SetInstructions(string instructions)
        {
            this.Instructions = instructions;
            return this;
        }
        public IRecipe SetAuthor(User author)
        {
            this.Author = author;
            return this;
        }
        public IRecipe SetIngredients(IEnumerable<Ingredient> ingredients)
        {
            this.Ingredients = ingredients;
            return this;
        }

        public IRecipe SetName(string name)
        {
            this.Name = name;
            return this;
        }
    }
}
