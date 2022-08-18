using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Managers.Recipes;

namespace Foodler.Repository.Tests.Managers.Recipes
{
    [TestClass]
    public class IngredientManagerTests
    {
        private readonly IEntityManager<Ingredient> ingredientManager;

        private const string ingredientName = "Kyckling";
        public IngredientManagerTests()
        {
            ingredientManager = new IngredientManager();
        }

        [TestMethod]
        public void Create_ValidParameters_ReturnsIngredient()
        {
            ////Arrange & Act
            var ingredient = ingredientManager.Create(ingredientName);

            ////Assert
            Assert.IsNotNull(ingredient);
            Assert.AreEqual(ingredientName, ingredient.Name);
        }

        [TestMethod]
        [DataRow("   ", DisplayName = "Name is whitespace")]
        [DataRow("", DisplayName = "Name is empty string")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Create_InvalidParameters_ThrowsArgumentException(string name)
        {
            ////Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ingredientManager.Create(name));
        }
    }
}
