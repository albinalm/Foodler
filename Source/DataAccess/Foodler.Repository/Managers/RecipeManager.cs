using Foodler.Repository.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Managers
{
    public class RecipeManager : IRecipeManager
    {
        public Entities.Recipe Create()
        {
            return new Entities.Recipe();
        }
        public void SetRecipeName(ref Entities.Recipe recipe, string name)
        {
            recipe.Name = name;
        }
    }
}
