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
    public class MeasurmentRepositoryTests
    {
        private const string measurmentName1 = "Tesked";
        private const string measurmentName2 = "Milliliter";
        private readonly string foodlerDatabaseName = "FoodlerInMemoryDatabase";
        private readonly Measurment[] SeedableMeasurments;
        private readonly IRepository<Measurment> Repository;

        public MeasurmentRepositoryTests()
        {
            var context = GetContext();

            //Ensures there is a fresh database each test
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Repository = new MeasurmentRepository(GetContext());
            SeedableMeasurments = new Measurment[]
            {
               new Measurment("Gram")
               {
                ShortName = "g"
               },
               new Measurment("Deciliter")
               {
                ShortName = "dl"
               },
               new Measurment("Styck")
               {
                ShortName = "st"
               },
               new Measurment("Matsked")
               {
                ShortName = "msk"
               },
            };
        }

        [TestInitialize]
        public void Initialize()
        {
            Repository.InsertRange(SeedableMeasurments);
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
        public void Insert_ValidMeasurment_MeasurmentAddedToDatabase()
        {
            ////Arrange
            var measurment = new Measurment(measurmentName1)
            {
                ShortName = "tsk"
            };

            ////Act
            Repository.Insert(measurment);
            Repository.Save();

            ////Assert
            Repository.Query().First(ic => ic.Name == measurmentName1);
        }

        [TestMethod]
        public void Insert_MeasurmentIsNull_ThrowsInvalidOperationException()
        {
            ////Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => Repository.Insert(null));
        }

        [TestMethod]
        public void InsertRange_ValidMeasurmentCategories_MeasurmentCategoriesAddedToDatabase()
        {
            ////Arrange
            var measurmentCategories = new Measurment[]
            {
            new Measurment(measurmentName1)
            {
                ShortName = "tsk"
            },
            new Measurment(measurmentName2)
            {
                ShortName = "ml"
            }
        };

            ////Act
            Repository.InsertRange(measurmentCategories);
            Repository.Save();

            ////Assert
            var result = Repository.Query()
                                   .Where(
                                          ic => ic.Name == measurmentName1 ||
                                          ic.Name == measurmentName2
                                          );

            Assert.IsTrue(result.Count() == 2);
        }

        [TestMethod]
        public void FindById_IdExistsInDatabase_ReturnsMeasurment()
        {
            ////Act
            var result = Repository.FindById(1);

            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(SeedableMeasurments[0].Name, result.Name);
            Assert.AreEqual(SeedableMeasurments[0].ShortName, result.ShortName);
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
        public void FindByName_NameExistsInDatabase_ReturnsMeasurment()
        {
            ////Act
            var result = Repository.FindByName(SeedableMeasurments[0].Name).First();

            ////Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(SeedableMeasurments[0].Name, result.Name);

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
        public void Delete_MeasurmentExistsInDatabase_DeletesMeasurment()
        {
            ////Act
            var measurment = Repository.FindByName("Gram").First();
            Repository.Delete(measurment);
            Repository.Save();

            ////Assert
            measurment = Repository.FindByName("Gram").FirstOrDefault();
            Assert.IsNull(measurment);
            Assert.IsTrue(Repository.Query().Count() == SeedableMeasurments.Length - 1);
        }

        [TestMethod]
        public void Delete_MeasurmentIsNull_ThrowsInvalidOperationException()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() => Repository.Delete(null));
            Assert.AreEqual(
                            "Entity cannot be null",
                            exception.Message
                            );
        }

        [TestMethod]
        public void Update_MeasurmentIsValid_MeasurmentIsUpdated()
        {
            var measurment = Repository.FindByName("Deciliter").First();
            measurment.SetName("DeciliterNy");

            Repository.Update(measurment);
            Repository.Save();

            measurment = Repository.FindByName("DeciliterNy").First();

            Assert.IsNotNull(measurment);

        }
    }
}
