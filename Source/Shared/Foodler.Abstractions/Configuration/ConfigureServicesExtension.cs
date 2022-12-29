using System.Reflection;
using AutoMapper;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Managers.Recipes;
using Foodler.Repository.Repositories;
using Foodler.Repository.Repositories.Interfaces;
using Foodler.Repository.Services;
using Foodler.Repository.Services.Interfaces;
using Foodler.Abstractions.Services;
using Foodler.Abstractions.Services.Interfaces;
using Foodler.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foodler.Abstractions.Configuration
{
    public static class ConfigureServicesExtension
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .Build();

            var connectionString = config.GetConnectionString("Domain");
            
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("A connection string needs to be provided");
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<FoodlerDatabaseContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("FoodlerDatabaseMigrationDummy")));

            services.AddScoped<IRepository<Recipe>, RecipeRepository>();
            services.AddScoped<IRepository<Ingredient>, IngredientRepository>();
            services.AddScoped<IRepository<Measurment>, MeasurmentRepository>();
            services.AddScoped<IRepository<IngredientCategory>, IngredientCategoryRepository>();

            services.AddScoped<IEntityManager<Recipe>, RecipeManager>();
            services.AddScoped<IEntityManager<Ingredient>, IngredientManager>();
            services.AddScoped<IEntityManager<Measurment>, MeasurmentManager>();
            services.AddScoped<IEntityManager<IngredientCategory>, IngredientCategoryManager>();

            services.AddScoped<IFoodlerRecipeService, FoodlerRecipeService>();

            services.AddScoped<IEntityValidationService, EntityValidationService>();
        }
    }
}
