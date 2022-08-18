using Foodler.Repository.Entities.Bases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Recipes.Interfaces
{
    public interface IIngredientCategory : IEntityBase
    {
        IIngredientCategory SetName(string name);
    }
}
