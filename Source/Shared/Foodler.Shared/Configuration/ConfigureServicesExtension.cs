using AutoMapper;
using Foodler.Repository.Database.Context;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Managers.Recipes;
using Foodler.Repository.Repositories;
using Foodler.Repository.Repositories.Interfaces;
using Foodler.Repository.Services;
using Foodler.Repository.Services.Interfaces;
using Foodler.Shared.Services;
using Foodler.Shared.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Foodler.Shared.Configuration
{
    public static class ConfigureServicesExtension
    {
        public static void RegisterRepository(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<FoodlerDatabaseContext>(options => options.UseSqlServer(@""));

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
