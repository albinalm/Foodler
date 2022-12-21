using Foodler.Abstractions.Models.Accounts;
using Foodler.Abstractions.Models.Bases;

namespace Foodler.Abstractions.Models.Recipes
{
    public class Recipe : ModelBase
    {
        public virtual IEnumerable<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public User Author { get; set; }
    }
}
