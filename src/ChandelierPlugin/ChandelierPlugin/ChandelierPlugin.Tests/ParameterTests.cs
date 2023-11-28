namespace ChandelierPlugin.Tests
{
    using System;
    using ChandelierPlugin.Model;
    using NUnit.Framework;

    [TestFixture]
    public class ParameterTests
    {
        [TestCase(5, 15, 1)]
        [TestCase(7, 10, 5)]
        [TestCase(50, 100, 10)]
        public void Parameter_Initialization_SetPropertiesCorrectly(
            double currentValue,
            double maxValue,
            double minValue)
        {
            // Arrange, Act
            var parameter = new Parameter(currentValue, maxValue, minValue);

            // Assert
            Assert.AreEqual(
                currentValue,
                parameter.CurrentValue);
            Assert.AreEqual(maxValue, parameter.MaxValue);
            Assert.AreEqual(minValue, parameter.MinValue);
        }

        [TestCase(5, 15, 1)]
        [TestCase(7, 10, 5)]
        [TestCase(50, 100, 10)]
        public void Parameter_SetProperties_UpdateValues(
            double currentValue,
            double maxValue,
            double minValue)
        {
            // Arrange
            var parameter = new Parameter();

            // Act
            parameter.CurrentValue = currentValue;
            parameter.MaxValue = maxValue;
            parameter.MinValue = minValue;

            // Assert
            Assert.AreEqual(
                currentValue,
                parameter.CurrentValue);
            Assert.AreEqual(maxValue, parameter.MaxValue);
            Assert.AreEqual(minValue, parameter.MinValue);
        }

        [TestCase(52.0, 10.0, 0)]
        [TestCase(67.0, 230.0, 111.0)]
        [TestCase(5.0, 23.0, 11.0)]
        public void Parameter_Initialization_CurrentValueOutOfRange_ThrowArgumentException(
            double currentValue,
            double maxValue,
            double minValue)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
                new Parameter(currentValue, maxValue, minValue));
        }

        [TestCase(5.0, 1.0, 3.0)]
        [TestCase(-5.0, -1.0, 3.0)]
        [TestCase(80.0, 80.0, 81.0)]
        public void Parameter_Initialization_MinValueGreaterThanMaxValue_ThrowArgumentException(
            double currentValue,
            double maxValue,
            double minValue)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
                new Parameter(currentValue, maxValue, minValue));
        }

        [TestCase(5.0, 4.0, 0)]
        [TestCase(15.0, 38.0, 0)]
        [TestCase(557.0, 4000.0, 0)]
        public void Parameter_Initialization_WithNegativeValues_ShouldThrowArgumentException(
            double currentValue,
            double maxValue,
            double minValue)
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() =>
                new Parameter(currentValue, maxValue, minValue));
        }
    }
}