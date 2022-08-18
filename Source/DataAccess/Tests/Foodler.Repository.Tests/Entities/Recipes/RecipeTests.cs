using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Entities.Security;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Tests.Entities.Recipes
{
    [TestClass]
    public class RecipeTests
    {
        private readonly Recipe recipe;
        private const string recipeName1 = "Mammas goda köttbullar";
        private const string instructions1 = "Instruktioner för köttbullar";

        public RecipeTests()
        {
            recipe = new Recipe("Placeholder");
        }
        [TestMethod]
        public void SetName_ValidName_NameIsSet()
        {
            ////Arrange & Act
            recipe.SetName(recipeName1);

            ////Assert
            Assert.IsTrue(recipe.Name == recipeName1);
        }

        [TestMethod]
        public void SetInstructions_ValidInstructions_InstructionsIsSet()
        {
            ////Arrange & Act
            recipe.SetInstructions(instructions1);

            ////Assert
            Assert.IsTrue(recipe.Instructions == instructions1);
        }

        [TestMethod]
        public void SetAuthor_ValidAuthor_AuthorIsSet()
        {
            ////Arrange
            var author = new User("TestUser");

            ////Act
            recipe.SetAuthor(author);

            ////Assert
            Assert.IsTrue(recipe.Author.Name == author.Name);
        }

        [TestMethod]
        public void SetIngredients_ValidIngredients_IngredientsIsSet()
        {
            ////Arrange
            var ingredients = new Ingredient[]
            {
                new Ingredient("Ingredient1"),
                new Ingredient("Ingredient2")
            };

            ////Act
            recipe.SetIngredients(ingredients);

            ////Assert
            Assert.IsTrue(recipe.Ingredients.First().Name == ingredients.First().Name);
            Assert.IsTrue(recipe.Ingredients.Last().Name == ingredients.Last().Name);
        }

        [TestMethod]
        public void Validate_ValidRecipe_ValidationSuccess()
        {
            ////Arrange
            var author = new User("Placeholder Andersson");
            var ingredients = new Ingredient[]
            {
                new Ingredient("Kyckling"),
                new Ingredient("Potatis")
            };

            recipe.SetName("Mammas goda soppa")
                  .SetInstructions("Instructions")
                  .SetAuthor(author)
                  .SetIngredients(ingredients);

            ////Act
            var validationContext = new ValidationContext(recipe, null, null);
            var validationResult = recipe.Validate(validationContext);

            ////Assert
            Assert.IsFalse(validationResult.Any(), "Validation result should be empty");
        }

        [TestMethod]
        [DataRow("", DisplayName = "Name is empty")]
        [DataRow(" ", DisplayName = "Name is whitespace")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Validate_RecipeHasInvalidName_ValidationFails(string name)
        {
            ////Arrange
            var author = new User("Placeholder Andersson");
            var ingredients = new Ingredient[]
            {
                new Ingredient("Kyckling"),
                new Ingredient("Potatis")
            };

            recipe.SetName(name)
                  .SetInstructions("Instructions")
                  .SetAuthor(author)
                  .SetIngredients(ingredients);

            ////Act
            var validationContext = new ValidationContext(recipe, null, null);
            var validationResult = recipe.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }

        [TestMethod]
        [DataRow("", DisplayName = "Instructions is empty")]
        [DataRow(" ", DisplayName = "Instructions is whitespace")]
        [DataRow(null, DisplayName = "Instructions is null")]
        public void Validate_RecipeHasInvalidInstructions_ValidationFails(string instructions)
        {
            ////Arrange
            var author = new User("Placeholder Andersson");
            var ingredients = new Ingredient[]
            {
                new Ingredient("Kyckling"),
                new Ingredient("Potatis")
            };

            recipe.SetName("Mammas goda soppa")
                  .SetInstructions(instructions)
                  .SetAuthor(author)
                  .SetIngredients(ingredients);

            ////Act
            var validationContext = new ValidationContext(recipe, null, null);
            var validationResult = recipe.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }

        [TestMethod]
        public void Validate_RecipeHasNoAuthor_ValidationFails()
        {
            ////Arrange
            var ingredients = new Ingredient[]
            {
                new Ingredient("Kyckling"),
                new Ingredient("Potatis")
            };

            recipe.SetName("Mammas goda soppa")
                  .SetInstructions("instructions")
                  .SetIngredients(ingredients);

            ////Act
            var validationContext = new ValidationContext(recipe, null, null);
            var validationResult = recipe.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }

        [TestMethod]
        public void Validate_RecipeHasNoIngredients_ValidationFails()
        {
            ////Arrange
            var author = new User("Placeholder Andersson");

            recipe.SetName("Mammas goda soppa")
                  .SetInstructions("instructions")
                  .SetAuthor(author);

            ////Act
            var validationContext = new ValidationContext(recipe, null, null);
            var validationResult = recipe.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }
    }
}
