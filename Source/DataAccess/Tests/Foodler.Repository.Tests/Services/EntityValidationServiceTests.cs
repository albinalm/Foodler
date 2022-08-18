using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Services;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Tests.Services
{
    [TestClass]
    public class EntityValidationServiceTests
    {
        private readonly EntityValidationService entityValidationService;
        public EntityValidationServiceTests()
        {
            entityValidationService = new EntityValidationService();
        }

        [TestMethod]
        public void ValidateEntities_EntityIsValid_ReturnsEmptyEnumerable()
        {
            ////Arrange
            var entities = new Measurment[]
            {
                (Measurment)new Measurment("Deciliter").SetShortName("dl"),
                (Measurment)new Measurment("Milliliter").SetShortName("ml")
            };

            ////Act
            var result = entityValidationService.ValidateEntities(entities);

            ////Assert
            Assert.IsFalse(result.Any(), "Validation result should be empty");
        }

        [TestMethod]
        public void ValidateEntities_EntityIsInvalidAndSilentIsFalse_ReturnsValidationResults()
        {
            ////Arrange
            var entities = new Measurment[]
            {
                new Measurment("Deciliter"),
                (Measurment)new Measurment("Milliliter").SetShortName("ml")
            };

            ////Act & Assert
            Assert.ThrowsException<ValidationException>(() => entityValidationService.ValidateEntities(entities, silent: false));
        }

        [TestMethod]
        public void ValidateEntities_EntityIsInvalidAndSilentIsTrue_ReturnsValidationResults()
        {
            ////Arrange
            var entities = new Measurment[]
            {
                new Measurment("Deciliter"),
                (Measurment)new Measurment("Milliliter").SetShortName("ml")
            };

            ////Act
            var result = entityValidationService.ValidateEntities(entities, silent: true);

            ////Assert
            Assert.IsTrue(result.Any(), "Validation result should contain one element");
        }
    }
}
