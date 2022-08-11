using Foodler.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foodler.Repository
{
    public class FoodlerRepository
    {
        private readonly FoodlerContext _db;
        public FoodlerRepository(FoodlerContext db) => _db = db;
        public IQueryable<Recipe> Recipes => _db.Recipes;
        public IQueryable<Ingredient> Ingredients => _db.Ingredients;
        public void Add<TEntityType>(TEntityType entity) => _db.Add(entity);
        public void Remove<TEntityType>(TEntityType entity) => _db.Remove(entity);
        public void SaveChanges() => _db.SaveChanges();
        public void Update<TEntityType>(TEntityType entity) => _db.Update(entity);
    }
}
