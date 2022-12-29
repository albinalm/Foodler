using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Entities.Security;
using Foodler.Repository.Repositories;
using Foodler.Repository.Repositories.Interfaces;
using Foodler.Repository.Services;
using Foodler.Repository.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foodler.Repository.Context;

namespace Foodler.Repository.Tests.Repositories
{
    [TestClass]
    public class RecipeRepositoryTests
    {
        private const string recipeName1 = "Köttbullar";
        private const string recipeName2 = "Fiskbullar";
        private readonly string foodlerDatabaseName = "FoodlerInMemoryDatabase";
        private readonly Recipe[] SeedableRecipes;
        private readonly IRepository<Recipe> Repository;

        public RecipeRepositoryTests()
        {
            var context = GetContext();

            //Ensures there is a fresh database each test
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Repository = new RecipeRepository(GetContext());
            SeedableRecipes = new Recipe[]
            {
               new Recipe("Tomatkyckling")
               {
                   Instructions = "Just do it good like you did before",
                   Author = new User("Placeholder Placeholdersson")
                   {
                       Email = "placeholder@placeholder.se",
                       Password = "Super secret hashed password"
                   },
                   Ingredients = new Ingredient[]
                   {
                        new Ingredient("Kyckling")
                        {
                            Quantity = 300,
                            Measurment = new Measurment("Gram")
                            {
                                ShortName = "g"
                            },
                            Category = new IngredientCategory("Fågel")
                        }
                   }
               },
               new Recipe("Fasters goda soppa")
               {
                   Instructions = "Just do it good",
                   Author = new User("Placeholder Placeholdersson")
                   {
                       Email = "placeholder@placeholder.se",
                       Password = "Super secret hashed password"
                   },
                   Ingredients = new Ingredient[]
                   {
                        new Ingredient("Mjölk")
                        {
                            Quantity = 3,
                            Measurment = new Measurment("Deciliter")
                            {
                                ShortName = "dl"
                            },
                            Category = new IngredientCategory("Mejeri")
                        }
                   }
               }
            };
        }

        [TestInitialize]
        public void Initialize()
        {
            Repository.InsertRange(SeedableRecipes);
            Repository.Save();
        }

        private FoodlerDatabaseContext GetContext()
        {
            var options = new DbContextOptionsBuilder<FoodlerDatabaseContext>()
                     .UseInMemoryDatabase(databaseName: foodlerDatabaseName)
                     .Options;

            return new FoodlerDatabaseContext(options, new EntityValidationService());
        }

        [TestMethod]
        public void Insert_ValidRecipe_RecipeAddedToDatabase()
        {
            ////Arrange
            var recipe = new Recipe(recipeName1)
            {
                Instructions = "Just do it good like you did before",
                Author = new User("Placeholder Placeholdersson")
                {
                    Email = "placeholder@placeholder.se",
                    Password = "Super secret hashed password"
                },
                Ingredients = new Ingredient[]
                   {
                        new Ingredient("Blandfärs")
                        {
                            Quantity = 500,
                            Measurment = new Measurment("Gram")
                            {
                                ShortName = "g"
                            },
                            Category = new IngredientCategory("Kött")
                        }
                   }
            };

            ////Act
            Repository.Insert(recipe);
            Repository.Save();

            ////Assert
            Repository.Query().First(ic => ic.Name == recipeName1);
        }

        [TestMethod]
        public void Insert_RecipeIsNull_ThrowsInvalidOperationException()
        {
            ////Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => Repository.Insert(null));
        }

        [TestMethod]
        public void InsertRange_ValidRecipeCategories_RecipeCategoriesAddedToDatabase()
        {
            ////Arrange
            var recipeCategories = new Recipe[]
            {
            new Recipe(recipeName1)
            {
                Instructions = "Just do it good like you did before",
                Author = new User("Placeholder Placeholdersson")
                {
                    Email = "placeholder@placeholder.se",
                    Password = "Super secret hashed password"
                },
                Ingredients = new Ingredient[]
                   {
                        new Ingredient("Blandfärs")
                        {
                            Quantity = 500,
                            Measurment = new Measurment("Gram")
                            {
                                ShortName = "g"
                            },
                            Category = new IngredientCategory("Kött")
                        }
                   }
            },
            new Recipe(recipeName2)
            {
                Instructions = "Just do it good like you did before",
                Author = new User("Placeholder Placeholdersson")
                {
                    Email = "placeholder@placeholder.se",
                    Password = "Super secret hashed password"
                },
                Ingredients = new Ingredient[]
                   {
                        new Ingredient("Fisk")
                        {
                            Quantity = 250,
                            Measurment = new Measurment("Gram")
                            {
                                ShortName = "g"
                            },
                            Category = new IngredientCategory("Fisk")
                        }
                   }
            }
        };

            ////Act
            Repository.InsertRange(recipeCategories);
            Repository.Save();

            ////Assert
            var result = Repository.Query()
                                   .Where(
                                          ic => ic.Name == recipeName1 ||
                                          ic.Name == recipeName2
                                          );

            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void FindById_IdExistsInDatabase_ReturnsRecipe()
        {
            ////Act
            var result = Repository.FindById(1);

            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(SeedableRecipes[0].Name, result.Name);
            Assert.AreEqual(SeedableRecipes[0].Instructions, result.Instructions);
            Assert.AreEqual(SeedableRecipes[0].Author, result.Author);
            Assert.AreEqual(SeedableRecipes[0].Ingredients, result.Ingredients);
        }

        [TestMethod]
        public void FindById_IdDoesNotExistsInDatabase_ReturnsNull()
        {
            ////Act
            var result = Repository.FindById(999);

            ////Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void FindByName_NameExistsInDatabase_ReturnsRecipe()
        {
            ////Act
            var result = Repository.FindByName("Tomatkyckling").First();

            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(SeedableRecipes[0].Name, result.Name);

        }

        [TestMethod]
        public void FindByName_NameDoesNotExistsInDatabase_ReturnsEmptyIQueryable()
        {
            ////Act
            var result = Repository.FindByName("Fel");

            ////Assert
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void FindByName_NameIsNull_ThrowsInvalidOperationException()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() => Repository.FindByName(null));
            Assert.AreEqual(
                            "Name cannot be null or whitespace",
                            exception.Message
                            );
        }

        [TestMethod]
        public void Delete_RecipeExistsInDatabase_DeletesRecipe()
        {
            ////Act
            var recipe = Repository.FindByName("Fasters goda soppa").First();
            Repository.Delete(recipe);
            Repository.Save();

            ////Assert
            recipe = Repository.FindByName("Fasters goda soppa").FirstOrDefault();
            Assert.IsNull(recipe);
            Assert.IsTrue(Repository.Query().Count() == SeedableRecipes.Length - 1);
        }

        [TestMethod]
        public void Delete_RecipeIsNull_ThrowsInvalidOperationException()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() => Repository.Delete(null));
            Assert.AreEqual(
                            "Entity cannot be null",
                            exception.Message
                            );
        }

        [TestMethod]
        public void Update_RecipeIsValid_RecipeIsUpdated()
        {
            var recipe = Repository.FindByName("Tomatkyckling").First();
            recipe.SetName("TomatkycklingNy");

            Repository.Update(recipe);
            Repository.Save();

            recipe = Repository.FindByName("TomatkycklingNy").First();

            Assert.IsNotNull(recipe);

        }
    }
}
