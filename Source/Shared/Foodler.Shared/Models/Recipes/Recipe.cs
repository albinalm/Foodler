using Foodler.Shared.Models.Accounts;
using Foodler.Shared.Models.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Shared.Models.Recipes
{
    public class Recipe : ModelBase
    {
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public string Instructions { get; set; }
        public User Author { get; set; }
    }
}
