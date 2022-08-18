using Foodler.Repository.Entities.Security;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Managers.Security;

namespace Foodler.Repository.Tests.Managers.Security
{
    [TestClass]
    public class UserManagerTests
    {
        private readonly IEntityManager<User> userManager;

        private const string userName = "Fasters goda soppa";
        public UserManagerTests()
        {
            userManager = new UserManager();
        }

        [TestMethod]
        public void Create_ValidParameters_ReturnsUser()
        {
            ////Arrange & Act
            var user = userManager.Create(userName);

            ////Assert
            Assert.IsNotNull(user);
            Assert.AreEqual(userName, user.Name);
        }

        [TestMethod]
        [DataRow("   ", DisplayName = "Name is whitespace")]
        [DataRow("", DisplayName = "Name is empty string")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Create_InvalidParameters_ThrowsArgumentException(string name)
        {
            ////Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => userManager.Create(name));
        }
    }
}
