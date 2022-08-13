using Foodler.Repository.Database.Context;
using Foodler.Repository.Database.Repositories;
using Foodler.Repository.Entities;
using Foodler.Repository.Managers;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Repositories.Interfaces;
using Foodler.Shared.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Foodler.Shared.Services.Configuration
{
    public static class ConfigureServicesExtension
    {
        public static void RegisterDataAccess(this IServiceCollection services)
        {
            services.AddScoped<FoodlerDatabaseContext>();
            services.AddScoped<IFoodlerRecipeService, FoodlerRecipeService>();
            services.AddScoped<IRepository<Recipe>, RecipeRepository>();
            services.AddScoped<IRecipeManager, RecipeManager>();
        }
    }
}
