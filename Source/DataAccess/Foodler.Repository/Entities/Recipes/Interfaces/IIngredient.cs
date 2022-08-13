using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Entities.Recipes.Interfaces
{
    public interface IIngredient
    {
        public long Quantity { get; set; }
        public Measurment Measurment { get; set; }
        public IngredientCategory Category { get; set; }
        IIngredient SetQuantity(long quantity);
        IIngredient SetMeasurment(Measurment measurment);
        IIngredient SetCategory(IngredientCategory category);
        IIngredient SetName(string name);

    }
}
