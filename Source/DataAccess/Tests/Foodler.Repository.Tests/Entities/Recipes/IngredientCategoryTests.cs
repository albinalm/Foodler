using Foodler.Repository.Entities.Recipes;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Tests.Entities.Recipes
{
    [TestClass]
    public class IngredientCategoryTests
    {
        private readonly IngredientCategory ingredientCategory;
        private const string ingredientCategoryName1 = "Schark";

        public IngredientCategoryTests()
        {
            ingredientCategory = new IngredientCategory("Placeholder");
        }
        [TestMethod]
        public void SetName_ValidName_NameIsSet()
        {
            ////Arrange & Act
            ingredientCategory.SetName(ingredientCategoryName1);

            ////Assert
            Assert.IsTrue(ingredientCategory.Name == ingredientCategoryName1);
        }
        [TestMethod]
        public void Validate_ValidIngredientCategory_ValidationSuccess()
        {
            ////Arrange
            ingredientCategory.SetName("Kyckling");

            ////Act
            var validationContext = new ValidationContext(ingredientCategory, null, null);
            var validationResult = ingredientCategory.Validate(validationContext);

            ////Assert
            Assert.IsFalse(validationResult.Any(), "Validation result should be empty");
        }

        [TestMethod]
        [DataRow("", DisplayName = "Name is empty")]
        [DataRow(" ", DisplayName = "Name is whitespace")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Validate_IngredientCategoryHasInvalidName_ValidationFails(string name)
        {
            ////Arrange
            ingredientCategory.SetName(name);

            ////Act
            var validationContext = new ValidationContext(ingredientCategory, null, null);
            var validationResult = ingredientCategory.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }
    }
}
