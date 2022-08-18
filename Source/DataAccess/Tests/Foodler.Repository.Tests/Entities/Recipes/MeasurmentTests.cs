using Foodler.Repository.Entities.Recipes;
using Foodler.Repository.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodler.Repository.Tests.Entities.Recipes
{
    [TestClass]
    public class UserTests
    {
        private readonly Measurment measurment;
        private const string measurmentName1 = "Milliliter";
        private const string measurmentShortName = "ml";

        public UserTests()
        {
            measurment = new Measurment("Placeholder");
        }

        [TestMethod]
        public void SetName_ValidName_NameIsSet()
        {
            ////Arrange & Act
            measurment.SetName(measurmentName1);

            ////Assert
            Assert.IsTrue(measurment.Name == measurmentName1);
        }

        [TestMethod]
        public void SetShortName_ValidShortName_ShortNameIsSet()
        {
            ////Arrange & Act
            measurment.SetShortName(measurmentShortName);

            ////Assert
            Assert.IsTrue(measurment.ShortName == measurmentShortName);
        }
        [TestMethod]
        public void Validate_ValidMeasurment_ValidationSuccess()
        {
            ////Arrange
            measurment.SetName("Kyckling").SetShortName("Placeholder");

            ////Act
            var validationContext = new ValidationContext(measurment, null, null);
            var validationResult = measurment.Validate(validationContext);

            ////Assert
            Assert.IsFalse(validationResult.Any(), "Validation result should be empty");
        }

        [TestMethod]
        [DataRow("", DisplayName = "Name is empty")]
        [DataRow(" ", DisplayName = "Name is whitespace")]
        [DataRow(null, DisplayName = "Name is null")]
        public void Validate_MeasurmentHasInvalidName_ValidationFails(string name)
        {
            ////Arrange
            measurment.SetName(name).SetShortName("Placeholder");

            ////Act
            var validationContext = new ValidationContext(measurment, null, null);
            var validationResult = measurment.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }

        [TestMethod]
        [DataRow("", DisplayName = "ShortName is empty")]
        [DataRow(" ", DisplayName = "ShortName is whitespace")]
        [DataRow(null, DisplayName = "ShortName is null")]
        public void Validate_MeasurmentHasInvalidShortName_ValidationFails(string name)
        {
            ////Arrange
            measurment.SetName("Placeholder").SetShortName(name);

            ////Act
            var validationContext = new ValidationContext(measurment, null, null);
            var validationResult = measurment.Validate(validationContext);

            ////Assert
            Assert.IsNotNull(validationResult);
            Assert.IsTrue(validationResult.Any(), "Validation result should contain one entry");
        }
    }
}
