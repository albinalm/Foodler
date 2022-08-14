using Foodler.Repository.Entities.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Database.Context
{
    public class FoodlerDatabaseContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Measurment> Measurments { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(@"");
        }
        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker
                .Entries()
                .Where(_ => _.State == EntityState.Added ||
                            _.State == EntityState.Modified);

            var entitiesAreValid = ValidateEntries(changedEntities);

            if (entitiesAreValid)
                return base.SaveChanges();

            return 0;
        }
        private bool ValidateEntries(IEnumerable<EntityEntry> entityEntries)
        {
            var failedValidations = new List<ValidationResult>();
            foreach (var e in entityEntries)
            {
                var vc = new ValidationContext(e.Entity, null, null);
                var success = Validator.TryValidateObject(
                    e.Entity, vc, failedValidations, validateAllProperties: true);
                if (!success)
                    throw new ValidationException($"Validation failed for entity: {e.Entity.GetType().Name}\n{failedValidations.First().ErrorMessage}");
            }

            if (failedValidations.Count > 0)
                return false;

            return true;

        }
    }

}
