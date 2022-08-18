using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Managers.Recipes;

namespace Foodler.Repository.Tests.Managers.Recipes
{
    [TestClass]
    public class RecipeManagerTests
    {
        private readonly IEntityManager<Recipe> recipeManager;

        private const string recipeName = "Fasters goda soppa";
        public RecipeManagerTests()
        {
            recipeManager = new RecipeManager();
        }

        [TestMethod]
        public void Create_ValidParameters_ReturnsRecipe()
        {
            ////Arrange & Act
            var recipe = recipeManager.Create(recipeName);

            ////Assert
            Assert.IsNotNull(recipe);
            Assert.AreEqual(recipeName, recipe.Name);
        }

        [TestMethod]
        [DataRow("   ", DisplayName = "Name is whitespace")]
        [DataRow("", DisplayName = "Name is empty string")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Create_InvalidParameters_ThrowsArgumentException(string name)
        {
            ////Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => recipeManager.Create(name));
        }
    }
}
