using Foodler.Repository.Entities.Security;
using System.ComponentModel.DataAnnotations;

namespace Foodler.Repository.Tests.Entities.Security
{
    [TestClass]
    public class UserTests
    {
        private readonly User user;
        private const string userName1 = "Sofia";
        private const string userEmail = "sofia@mail.com";
        private const string userPassword = "sofisan";

        public UserTests()
        {
            user = new User("Placeholder");
        }

        [TestMethod]
        public void SetName_ValidName_NameIsSet()
        {
            ////Arrange & Act
            user.SetName(userName1);

            ////Assert
            Assert.IsTrue(user.Name == userName1);
        }

        [TestMethod]
        public void SetEmail_ValidEmail_EmailIsSet()
        {
            ////Arrange & Act
            user.SetEmail(userEmail);

            ////Assert
            Assert.IsTrue(user.Email == userEmail);
        }

        [TestMethod]
        public void SetPassword_ValidPassword_PasswordIsSet()
        {
            ////Arrange & Act
            user.SetPassword(userPassword);

            ////Assert
            Assert.IsTrue(user.Password == userPassword);
        }

        [TestMethod]
        public void Validate_ValidUser_ValidationSuccess()
        {
            ////Arrange
            user.SetName("Placeholder").SetEmail("placeholder@placeholder.se").SetPassword("temp123");

            ////Act
            var validationContext = new ValidationContext(user, null, null);
            var validationResult = user.Validate(validationContext);

            ////Assert
            Assert.IsFalse(validationResult.Any(), "Validation result should be empty");
        }

        [TestMethod]
        [DataRow("", DisplayName = "Name is empty")]
        [DataRow(" ", DisplayName = "Name is whitespace")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Validate_UserHasInvalidName_ValidationFails(string name)
        {
            ////Arrange
            user.SetName(name).SetEmail("placeholder@placeholder.se").SetPassword("temp");

            ////Act
            var validationContext = new ValidationContext(user, null, null);
            var validationResult = user.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should be contain one entry");
        }

        [TestMethod]
        [DataRow("", DisplayName = "Email is empty")]
        [DataRow(" ", DisplayName = "Email is whitespace")]
        [DataRow(null, DisplayName = "Email is null")]
        public void Validate_UserHasInvalidEmail_ValidationFails(string email)
        {
            ////Arrange
            user.SetName("Placeholder").SetEmail(email).SetPassword("temp");

            ////Act
            var validationContext = new ValidationContext(user, null, null);
            var validationResult = user.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should be contain one entry");
        }

        [TestMethod]
        [DataRow("", DisplayName = "Password is empty")]
        [DataRow(" ", DisplayName = "Password is whitespace")]
        [DataRow(null, DisplayName = "Password is null")]
        public void Validate_UserHasInvalidPassword_ValidationFails(string password)
        {
            ////Arrange
            user.SetName("Placeholder").SetEmail("placeholder@placeholder.se").SetPassword(password);

            ////Act
            var validationContext = new ValidationContext(user, null, null);
            var validationResult = user.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should be contain one entry");
        }
    }
}
