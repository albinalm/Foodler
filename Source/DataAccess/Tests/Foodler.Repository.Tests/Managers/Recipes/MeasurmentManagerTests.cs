using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Managers.Interfaces;
using Foodler.Repository.Managers.Recipes;

namespace Foodler.Repository.Tests.Managers.Recipes
{
    [TestClass]
    public class MeasurmentManagerTests
    {
        private readonly IEntityManager<Measurment> measurmentManager;

        private const string measurmentName = "Fasters goda soppa";
        public MeasurmentManagerTests()
        {
            measurmentManager = new MeasurmentManager();
        }

        [TestMethod]
        public void Create_ValidParameters_ReturnsMeasurment()
        {
            ////Arrange & Act
            var measurment = measurmentManager.Create(measurmentName);

            ////Assert
            Assert.IsNotNull(measurment);
            Assert.AreEqual(measurmentName, measurment.Name);
        }

        [TestMethod]
        [DataRow("   ", DisplayName = "Name is whitespace")]
        [DataRow("", DisplayName = "Name is empty string")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Create_InvalidParameters_ThrowsArgumentException(string name)
        {
            ////Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => measurmentManager.Create(name));
        }
    }
}
