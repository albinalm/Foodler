using Foodler.Models.Recipes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foodler.Repository
{
    public class FoodlerContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            //Connection string in a local txt file as a temporary solution. File is gitignored 
            optionsbuilder.UseSqlServer(@"");
        }
    }
}
