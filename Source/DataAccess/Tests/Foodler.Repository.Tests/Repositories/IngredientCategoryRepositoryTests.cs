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
    public class IngredientCategoryRepositoryTests
    {
        private const string ingredientCategoryName1 = "ValidIngredientCategoryName1";
        private const string ingredientCategoryName2 = "ValidIngredientCategoryName2";
        private readonly string foodlerDatabaseName = "FoodlerInMemoryDatabase";
        private readonly IngredientCategory[] SeedableIngredientCategories;
        private readonly IRepository<IngredientCategory> Repository;

        public IngredientCategoryRepositoryTests()
        {
            var context = GetContext();

            //Ensures there is a fresh database each test
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Repository = new IngredientCategoryRepository(GetContext());
            SeedableIngredientCategories = new IngredientCategory[]
            {
               new IngredientCategory("Grönsaker"),
               new IngredientCategory("Kött"),
               new IngredientCategory("Fågel"),
               new IngredientCategory("Fisk"),
               new IngredientCategory("Torrvaror"),
               new IngredientCategory("Frukt")
            };
        }

        [TestInitialize]
        public void Initialize()
        {
            Repository.InsertRange(SeedableIngredientCategories);
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
        public void Insert_ValidIngredientCategory_IngredientCategoryAddedToDatabase()
        {
            ////Arrange
            var ingredientCategory = new IngredientCategory(ingredientCategoryName1);

            ////Act
            Repository.Insert(ingredientCategory);
            Repository.Save();

            ////Assert
            Repository.Query().First(ic => ic.Name == ingredientCategoryName1);
        }

        [TestMethod]
        public void Insert_IngredientCategoryIsNull_ThrowsInvalidOperationException()
        {
            ////Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => Repository.Insert(null));
        }

        [TestMethod]
        public void InsertRange_ValidIngredientCategories_IngredientCategoriesAddedToDatabase()
        {
            ////Arrange
            var ingredientCategories = new IngredientCategory[]
            {
                new IngredientCategory(ingredientCategoryName1),
                 new IngredientCategory(ingredientCategoryName2)
            };

            ////Act
            Repository.InsertRange(ingredientCategories);
            Repository.Save();

            ////Assert
            var result = Repository.Query()
                                   .Where(
                                          ic => ic.Name == ingredientCategoryName1 ||
                                          ic.Name == ingredientCategoryName2
                                          );

            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void FindById_IdExistsInDatabase_ReturnsIngredientCategory()
        {
            ////Act
            var result = Repository.FindById(1);

            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(SeedableIngredientCategories[0], result);

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
        public void FindByName_NameExistsInDatabase_ReturnsIngredientCategory()
        {
            ////Act
            var result = Repository.FindByName("Grönsaker").First();

            ////Assert
            Assert.AreEqual(SeedableIngredientCategories[0], result);

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
        public void Delete_IngredientCategoryExistsInDatabase_DeletesIngredientCategory()
        {
            ////Act
            var ingredientCategory = Repository.FindById(6);
            Repository.Delete(ingredientCategory);
            Repository.Save();

            ////Assert
            ingredientCategory = Repository.FindById(6);
            Assert.IsNull(ingredientCategory);
            Assert.IsTrue(Repository.Query().Count() == SeedableIngredientCategories.Length - 1);
        }

        [TestMethod]
        public void Delete_IngredientCategoryIsNull_ThrowsInvalidOperationException()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() => Repository.Delete(null));
            Assert.AreEqual(
                            "Entity cannot be null",
                            exception.Message
                            );
        }

        [TestMethod]
        public void Update_IngredientCategoryIsValid_IngredientCategoryIsUpdated()
        {
            var ingredientCategory = Repository.FindByName("Kött").First();
            ingredientCategory.SetName("KöttNy");

            Repository.Update(ingredientCategory);
            Repository.Save();

            ingredientCategory = Repository.FindByName("KöttNy").First();

            Assert.IsNotNull(ingredientCategory);

        }

    }
}
