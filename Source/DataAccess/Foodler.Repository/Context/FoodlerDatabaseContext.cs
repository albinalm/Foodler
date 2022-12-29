using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Foodler.Repository.Context
{
    public class FoodlerDatabaseContext : DbContext
    {
        private readonly IEntityValidationService validationService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Measurment> Measurments { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
        public FoodlerDatabaseContext(IEntityValidationService validationService)
        {
            this.validationService = validationService;
        }
        public FoodlerDatabaseContext(DbContextOptions options, IEntityValidationService validationService) : base(options)
        {
            this.validationService = validationService;
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                        .HasIndex(u => u.Name)
                        .IsUnique();
        }
        #region Overrides

        public override int SaveChanges()
        {
            var changedEntities = ChangeTracker.Entries()
                                               .Where(_ => _.State == EntityState.Added ||
                                                           _.State == EntityState.Modified)
                                               .Select(entry => (EntityBase)entry.Entity);

            var validationResult = validationService.ValidateEntities(changedEntities);

            if (!validationResult.Any())
                return base.SaveChanges();

            return 0;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changedEntities = ChangeTracker.Entries()
                                               .Where(_ => _.State == EntityState.Added ||
                                                           _.State == EntityState.Modified)
                                               .Select(entry => (EntityBase)entry.Entity);

            var validationResult = validationService.ValidateEntities(changedEntities);

            if (!validationResult.Any())
                return base.SaveChangesAsync(cancellationToken);

            return Task.FromResult(0);

        }

        #endregion

    }
}
