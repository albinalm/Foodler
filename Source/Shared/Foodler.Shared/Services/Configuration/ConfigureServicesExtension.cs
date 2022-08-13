using AutoMapper;
using Foodler.Repository.Database.Context;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Entities.Recipes.Interfaces;
using Foodler.Repository.Managers;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Repositories;
using Foodler.Repository.Repositories.Interfaces;
using Foodler.Shared.MappingProfiles;
using Foodler.Shared.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Foodler.Shared.Services.Configuration
{
    public static class ConfigureServicesExtension
    {
        public static void RegisterDataAccess(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<FoodlerDatabaseContext>();
            services.AddScoped<IRepository<Recipe>, RecipeRepository>();
            services.AddScoped<IRepository<Ingredient>, IngredientRepository>();
            services.AddScoped<IRepository<Measurment>, MeasurmentRepository>();
            services.AddScoped<IRepository<IngredientCategory>, IngredientCategoryRepository>();
            services.AddScoped<IEntityManager<Recipe>, RecipeManager>();
            services.AddScoped<IEntityManager<Ingredient>, IngredientManager>();
            services.AddScoped<IEntityManager<Measurment>, MeasurmentManager>();
            services.AddScoped<IEntityManager<IngredientCategory>, IngredientCategoryManager>();
            services.AddScoped<IFoodlerRecipeService, FoodlerRecipeService>();
        }
        public static void ConfigureAutoMapper()
        {

        }
    }
}
