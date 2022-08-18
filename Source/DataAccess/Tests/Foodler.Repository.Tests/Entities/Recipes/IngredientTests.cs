using Foodler.Repository.Entities.Recipes;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Tests.Entities.Recipes
{
    [TestClass]
    public class IngredientTests
    {
        private readonly Ingredient ingredient;

        private const string ingredientName1 = "Kyckling";
        private const long quantity1 = 2;

        public IngredientTests()
        {
            ingredient = new Ingredient("Placeholder");

        }
        [TestMethod]
        public void SetName_ValidName_NameIsSet()
        {
            ////Arrange & Act
            ingredient.SetName(ingredientName1);

            ////Assert
            Assert.IsTrue(ingredient.Name == ingredientName1);
        }

        [TestMethod]
        public void SetQuantity_ValidQuantity_QuantityIsSet()
        {
            ////Arrange & Act
            ingredient.SetQuantity(quantity1);

            ////Assert
            Assert.IsTrue(ingredient.Quantity == quantity1);
        }

        [TestMethod]
        public void SetMeasurment_ValidMeasurment_MeasurmentIsSet()
        {
            ////Arrange
            var measurment = new Measurment("Deciliter");

            ////Act
            ingredient.SetMeasurment(measurment);

            ////Assert
            Assert.IsTrue(ingredient.Measurment.Name == measurment.Name);
        }

        [TestMethod]
        public void SetCategory_ValidCategory_CategoryIsSet()
        {
            ////Arrange
            var category = new IngredientCategory("Schark");

            ////Act
            ingredient.SetCategory(category);

            ////Assert
            Assert.IsTrue(ingredient.Category.Name == category.Name);
        }

        [TestMethod]
        public void Validate_ValidIngredient_ValidationSuccess()
        {
            ////Arrange
            var measurment = new Measurment("Deciliter").SetShortName("dl");
            var category = new IngredientCategory("Kött, Fisk & Fågel");
            ingredient.SetName("Kyckling").SetQuantity(2)
                                          .SetMeasurment(measurment)
                                          .SetCategory(category);

            ////Act
            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResult = ingredient.Validate(validationContext);

            ////Assert
            Assert.IsFalse(validationResult.Any(), "Validation result should be empty");
        }

        [TestMethod]
        public void Validate_IngredientHasNoQuantity_ValidationFails()
        {
            ////Arrange

            var measurment = new Measurment("Deciliter").SetShortName("dl");
            var category = new IngredientCategory("Kött, Fisk & Fågel");
            ingredient.SetName("Kyckling").SetQuantity(0)
                                          .SetMeasurment(measurment)
                                          .SetCategory(category);

            ////Act
            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResult = ingredient.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }

        [TestMethod]
        public void Validate_IngredientHasNoMeasurment_ValidationFails()
        {
            ////Arrange
            var category = new IngredientCategory("Kött, Fisk & Fågel");
            ingredient.SetName("Kyckling").SetQuantity(2)
                                          .SetCategory(category);


            ////Act
            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResult = ingredient.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }

        [TestMethod]
        public void Validate_IngredientHasNoCategory_ValidationFails()
        {
            ////Arrange
            var measurment = new Measurment("Deciliter").SetShortName("dl");
            ingredient.SetName("Kyckling").SetQuantity(0)
                                          .SetMeasurment(measurment);

            ////Act
            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResult = ingredient.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }

        [TestMethod]
        [DataRow("", DisplayName = "Name is empty")]
        [DataRow(" ", DisplayName = "Name is whitespace")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Validate_IngredientHasInvalidName_ValidationFails(string name)
        {
            ////Arrange
            var measurment = new Measurment("Deciliter").SetShortName("dl");
            var category = new IngredientCategory("Kött, Fisk & Fågel");
            ingredient.SetName(name).SetQuantity(0)
                                          .SetMeasurment(measurment)
                                          .SetCategory(category);

            ////Act
            var validationContext = new ValidationContext(ingredient, null, null);
            var validationResult = ingredient.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }

    }
}
