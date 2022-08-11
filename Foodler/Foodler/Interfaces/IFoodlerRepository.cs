using Foodler.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foodler.Interfaces
{
    public interface IFoodlerRepository
    {
        IQueryable<Recipe> Recipes { get; }
        IQueryable<Ingredient> Ingredients { get; }
        void Add<TEntityType>(TEntityType entity);
        void Update<TEntityType>(TEntityType entity);
        void Remove<TEntityType>(TEntityType entity);
        void SaveChanges();
    }
}
