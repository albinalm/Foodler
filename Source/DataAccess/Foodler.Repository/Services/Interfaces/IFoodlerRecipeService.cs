using FoodlerRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodlerRepository.Services.Interfaces
{
    public interface IFoodlerRecipeService
    {
        void AddRecipe(Recipe recipe);
    }
}
