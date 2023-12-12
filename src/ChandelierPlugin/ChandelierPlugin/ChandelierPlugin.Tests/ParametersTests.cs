namespace ChandelierPlugin.Tests
{
    using System;
    using ChandelierPlugin.Model;
    using NUnit.Framework;

    [TestFixture]
    internal class ParametersTests
    {
        [TestCase(
            ParameterType.RadiusInnerCircle,
            45,
            50,
            25,
            30)]
        [TestCase(
            ParameterType.RadiusOuterCircle,
            77,
            127,
            76,
            100)]
        [TestCase(
            ParameterType.LampRadius,
            12,
            43,
            1,
            15)]
        public void AssertParameter_Parameter_UpdateParameter(
            ParameterType parameterType,
            double currentValue,
            double maxValue,
            double minValue,
            double value)
        {
            // Arrange
            var parameters = new Parameters();
            Parameter parameter = new Parameter(
                currentValue,
                maxValue,
                minValue);

            // Act
            parameters.AssertParameter(parameterType, parameter, value);

            // Assert
            Assert.AreEqual(
                value,
                parameters.ParametersDict[parameterType].CurrentValue);
        }

        [TestCase(
            ParameterType.RadiusInnerCircle,
            45,
            50,
            25,
            0)]
        [TestCase(
            ParameterType.RadiusOuterCircle,
            77,
            127,
            76,
            1000)]
        [TestCase(
            ParameterType.LampRadius,
            12,
            43,
            1,
            0)]
        public void AssertParameter_WrongParameterValue_ThrowException(
            ParameterType parameterType,
            double currentValue,
            double maxValue,
            double minValue,
            double value)
        {
            // Arrange
            var parameters = new Parameters();
            Parameter parameter = new Parameter(
                currentValue,
                maxValue,
                minValue);

            // Act, Assert
            Assert.Throws<ArgumentException>(() =>
                parameters.AssertParameter(parameterType, parameter, value));
        }

        [TestCase(new[]
        {
            ParameterType.RadiusOuterCircle,
            ParameterType.RadiusInnerCircle,
            ParameterType.RadiusBaseCircle,
            ParameterType.FoundationThickness,
            ParameterType.LampsAmount,
            ParameterType.LampRadius,
            ParameterType.LayersAmount,
            ParameterType.ParameterMultiplier
        }, new[]
        {
            800.0,
            700.0,
            100.0,
            60.0,
            12.0,
            20.0,
            1.0,
            1.0
        })]
        public void GetParametersCurrentValues_CurrentValuesAreEqual(
            ParameterType[] parametersTypes,
            double[] currentValues)
        {
            // Arrange
            var parameters = new Parameters();
            var parametersDict =
                parameters.GetParametersCurrentValues();

            // Act
            for (var i = 0; i < parametersTypes.Length; i++)
            {
                var type = parametersTypes[i];
                var currentValue = currentValues[i];

                // Assert
                Assert.AreEqual(currentValue, parametersDict[type]);
            }
        }

        [TestCase(
            ParameterType.RadiusInnerCircle,
            700,
            751,
            149,
            new[] {ParameterType.RadiusOuterCircle},
            new[] { 800.0, 1000.0, 749.0 })]
        [TestCase(
            ParameterType.RadiusOuterCircle,
            800,
            1000,
            749,
            new[] { ParameterType.RadiusInnerCircle },
            new[] { 700.0, 751.0, 150.0 })]
        [TestCase(
            ParameterType.RadiusBaseCircle,
            100,
            651,
            100,
            new[] { ParameterType.RadiusInnerCircle },
            new[] { 700.0, 750.0, 149.0 })]
        [TestCase(
            ParameterType.LampRadius,
            20,
            25,
            15,
            new[] { ParameterType.LampsAmount },
            new[] { 12.0, 109.0, 1.0 })]
        public void ChangeParametersRangeValues_Parameter_UpdateRangeValues(
            ParameterType parameterType,
            double currentValue,
            double maxValue,
            double minValue,
            ParameterType[] parametersTypes,
            double[] expectedParameters)
        {
            // Arrange
            var parameters = new Parameters();
            Parameter parameter = new Parameter(
                currentValue,
                maxValue,
                minValue);
            var step = 0;

            // Act
            parameters.ChangeParametersRangeValues(parameterType, parameter);

            // Assert
            foreach (var item in parametersTypes)
            {
                var currentParameter = parameters.ParametersDict[item];

                Assert.AreEqual(
                    expectedParameters[step],
                    currentParameter.CurrentValue);
                Assert.AreEqual(
                    expectedParameters[step + 1],
                    currentParameter.MaxValue);
                Assert.AreEqual(
                    expectedParameters[step + 2],
                    currentParameter.MinValue);

                step += 3;
            }
        }

        [TestCase(
            ParameterType.LampsAmount,
            20,
            25,
            15)]
        [TestCase(
            ParameterType.FoundationThickness,
            20,
            25,
            15)]
        [TestCase(
            ParameterType.LayersAmount,
            20,
            25,
            15)]
        [TestCase(
            ParameterType.ParameterMultiplier,
            20,
            25,
            15)]
        public void ChangeParametersRangeValues_Parameter_NothingHappens(
            ParameterType parameterType,
            double currentValue,
            double maxValue,
            double minValue)
        {
            // Arrange
            var parameters = new Parameters();
            Parameter parameter = new Parameter(
                currentValue,
                maxValue,
                minValue);

            // Act, Assert
            Assert.DoesNotThrow(() =>
                parameters.ChangeParametersRangeValues(parameterType, parameter));
        }

        [TestCase(
            ParameterType.Unknown,
            20,
            25,
            15)]
        public void ChangeParametersRangeValues_Parameter_ThrowException(
            ParameterType parameterType,
            double currentValue,
            double maxValue,
            double minValue)
        {
            // Arrange
            var parameters = new Parameters();
            Parameter parameter = new Parameter(
                currentValue,
                maxValue,
                minValue);

            // Act, Assert
            Assert.Throws<ArgumentException>(() =>
                parameters.ChangeParametersRangeValues(parameterType, parameter));
        }
    }
}