using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Managers.Recipes;

namespace Foodler.Repository.Tests.Managers.Recipes
{
    [TestClass]
    public class IngredientCategoryManagerTests
    {
        private readonly IEntityManager<IngredientCategory> ingredientCategoryManager;

        private const string ingredientCategoryName = "Kött, Fisk & Fågel";
        public IngredientCategoryManagerTests()
        {
            ingredientCategoryManager = new IngredientCategoryManager();
        }

        [TestMethod]
        public void Create_ValidParameters_ReturnsIngredientCategory()
        {
            ////Arrange & Act
            var ingredientCategory = ingredientCategoryManager.Create(ingredientCategoryName);

            ////Assert
            Assert.IsNotNull(ingredientCategory);
            Assert.AreEqual(ingredientCategoryName, ingredientCategory.Name);
        }

        [TestMethod]
        [DataRow("   ", DisplayName = "Name is whitespace")]
        [DataRow("", DisplayName = "Name is empty string")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Create_InvalidParameters_ThrowsArgumentException(string name)
        {
            ////Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ingredientCategoryManager.Create(name));
        }
    }
}
