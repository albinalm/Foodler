using FoodlerRepository.Database.Context;
using FoodlerRepository.Database.Repositories;
using FoodlerRepository.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodlerRepository.Services.Configuration
{
    public static class ConfigureServicesExtension
    {
        public static void RegisterDataAccess(this IServiceCollection services)
        {
            services.AddScoped<FoodlerDatabaseContext>();
            services.AddScoped<IFoodlerRecipeService, FoodlerRecipeService>();
            services.AddScoped<RecipeRepository>();
        }
    }
}
