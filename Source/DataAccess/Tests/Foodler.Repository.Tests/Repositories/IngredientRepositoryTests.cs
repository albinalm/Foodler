using Foodler.Repository.Database.Context;
using Foodler.Repository.Entities.Bases;
using Foodler.Repository.Entities.Recipes;
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

namespace Foodler.Repository.Tests.Repositories
{
    [TestClass]
    public class IngredientRepositoryTests
    {
        private const string ingredientName1 = "Isbergssallad";
        private const string ingredientName2 = "Tomatsås";
        private readonly string foodlerDatabaseName = "FoodlerInMemoryDatabase";
        private readonly Ingredient[] SeedableIngredients;
        private readonly IRepository<Ingredient> Repository;

        public IngredientRepositoryTests()
        {
            var context = GetContext();

            //Ensures there is a fresh database each test
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Repository = new IngredientRepository(GetContext());
            SeedableIngredients = new Ingredient[]
            {
               new Ingredient("Kyckling")
               {
                   Quantity = 300,
                   Measurment = new Measurment("Gram")
                   {
                       ShortName = "g"
                   },
                   Category = new IngredientCategory("Fågel")
               },
               new Ingredient("Mjölk")
               {
                   Quantity = 3,
                   Measurment = new Measurment("Deciliter")
                   {
                       ShortName = "dl"
                   },
                   Category = new IngredientCategory("Mejeri")
               },
               new Ingredient("Vatten")
               {
                   Quantity = 2,
                   Measurment = new Measurment("Matskedar")
                   {
                       ShortName = "msk"
                   },
                   Category = new IngredientCategory("Övrigt")
               },
               new Ingredient("Buljong")
               {
                   Quantity = 1,
                   Measurment = new Measurment("styck")
                   {
                       ShortName = "st"
                   },
                   Category = new IngredientCategory("Torrvaror")
               },
               new Ingredient("Basilika")
               {
                   Quantity = 30,
                   Measurment = new Measurment("Gram")
                   {
                       ShortName = "g"
                   },
                   Category = new IngredientCategory("Kryddor & Örter")
               },
               new Ingredient("Potatis")
               {
                   Quantity = 430,
                   Measurment = new Measurment("Gram")
                   {
                       ShortName = "g"
                   },
                   Category = new IngredientCategory("Torrvaror")
            }
            };
        }

        [TestInitialize]
        public void Initialize()
        {
            Repository.InsertRange(SeedableIngredients);
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
        public void Insert_ValidIngredient_IngredientAddedToDatabase()
        {
            ////Arrange
            var ingredient = new Ingredient(ingredientName1)
            {
                Quantity = 1,
                Measurment = new Measurment("Styck")
                {
                    ShortName = "st"
                },
                Category = new IngredientCategory("Grönsaker")
            };

            ////Act
            Repository.Insert(ingredient);
            Repository.Save();

            ////Assert
            Repository.Query().First(ic => ic.Name == ingredientName1);
        }
        [TestMethod]
        public void Insert_IngredientIsNull_ThrowsInvalidOperationException()
        {
            ////Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => Repository.Insert(null));
        }

        [TestMethod]
        public void InsertRange_ValidIngredientCategories_IngredientCategoriesAddedToDatabase()
        {
            ////Arrange
            var ingredientCategories = new Ingredient[]
            {
            new Ingredient(ingredientName1)
            {
                Quantity = 1,
                Measurment = new Measurment("Styck")
                {
                    ShortName = "st"
                },
                Category = new IngredientCategory("Grönsaker")
            },
            new Ingredient(ingredientName2)
            {
                Quantity = 1,
                Measurment = new Measurment("Deciliter")
                {
                    ShortName = "dl"
                },
                Category = new IngredientCategory("Såses")
            }
        };

            ////Act
            Repository.InsertRange(ingredientCategories);
            Repository.Save();

            ////Assert
            var result = Repository.Query()
                                   .Where(
                                          ic => ic.Name == ingredientName1 ||
                                          ic.Name == ingredientName2
                                          );

            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void FindById_IdExistsInDatabase_ReturnsIngredient()
        {
            ////Act
            var result = Repository.FindById(1);

            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(SeedableIngredients[0].Name, result.Name);
            Assert.AreEqual(SeedableIngredients[0].Measurment, result.Measurment);
            Assert.AreEqual(SeedableIngredients[0].Quantity, result.Quantity);

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
        public void FindByName_NameExistsInDatabase_ReturnsIngredient()
        {
            ////Act
            var result = Repository.FindByName("Kyckling").First();

            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(SeedableIngredients[0].Name, result.Name);

        }

        [TestMethod]
        public void FindByName_NameDoesNotExistsInDatabase_ReturnsNull()
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
        public void Delete_IngredientExistsInDatabase_DeletesIngredient()
        {
            ////Act
            var ingredient = Repository.FindByName("Potatis").First();
            Repository.Delete(ingredient);
            Repository.Save();

            ////Assert
            ingredient = Repository.FindById(6);
            Assert.IsNull(ingredient);
            Assert.IsTrue(Repository.Query().Count() == SeedableIngredients.Length - 1);
        }

        [TestMethod]
        public void Delete_IngredientIsNull_ThrowsInvalidOperationException()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() => Repository.Delete(null));
            Assert.AreEqual(
                            "Entity cannot be null",
                            exception.Message
                            );
        }

        [TestMethod]
        public void Update_IngredientIsValid_IngredientIsUpdated()
        {
            var ingredient = Repository.FindByName("Kyckling").First();
            ingredient.SetName("KycklingNy");

            Repository.Update(ingredient);
            Repository.Save();

            ingredient = Repository.FindByName("KycklingNy").First();

            Assert.IsNotNull(ingredient);

        }

    }
}
