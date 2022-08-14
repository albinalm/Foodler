using Foodler.Shared.Models.Accounts;
using Foodler.Shared.Models.Bases;

namespace Foodler.Shared.Models.Recipes
{
    public class Recipe : ModelBase
    {
        public virtual IEnumerable<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public User Author { get; set; }
    }
}
