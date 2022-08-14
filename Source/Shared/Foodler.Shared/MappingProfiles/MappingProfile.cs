﻿using AutoMapper;
using Foodler.Repository.Entities.Accounts;
using Foodler.Repository.Entities.Recipes;

namespace Foodler.Shared.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Recipe, Models.Recipes.Recipe>();
            CreateMap<Models.Recipes.Recipe, Recipe>();

            CreateMap<Ingredient, Models.Recipes.Ingredient>();
            CreateMap<Models.Recipes.Ingredient, Ingredient>();

            CreateMap<IngredientCategory, Models.Recipes.IngredientCategory>();
            CreateMap<Models.Recipes.IngredientCategory, IngredientCategory>();

            CreateMap<Measurment, Models.Recipes.Measurment>();
            CreateMap<Models.Recipes.Measurment, Measurment>();

            CreateMap<User, Models.Accounts.User>();
            CreateMap<Models.Accounts.User, User>();
        }
    }
}
