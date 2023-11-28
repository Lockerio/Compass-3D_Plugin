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
            // TODO: поменять на отлов конкретного исключения
            Assert.Throws<Exception>(() =>
                parameters.AssertParameter(parameterType, parameter, value));
        }

        [TestCase(
            ParameterType.RadiusInnerCircle,
            700,
            751,
            149)]
        [TestCase(
            ParameterType.RadiusOuterCircle,
            800,
            1000,
            749)]
        [TestCase(
            ParameterType.RadiusBaseCircle,
            100,
            651,
            100)]
        [TestCase(
            ParameterType.LampRadius,
            20,
            25,
            15)]
        // TODO: добавить еще два входных параметра: массив ParameterType и массив ожидаемых значений
        public void ChangeParametersRangeValues_Parameter_UpdateRangeValues(
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

            // Act
            parameters.ChangeParametersRangeValues(parameterType, parameter);

            // Assert
            switch (parameterType)
            {
                case ParameterType.RadiusOuterCircle:
                    Assert.AreEqual(
                        parameters.ParametersDict[ParameterType.
                            RadiusInnerCircle].MaxValue,

                        // TODO: Магическое число
                        parameter.CurrentValue - 49);
                    break;

                case ParameterType.RadiusInnerCircle:
                    Assert.AreEqual(
                        parameters.ParametersDict[ParameterType.
                                RadiusOuterCircle].MinValue,
                        parameter.CurrentValue + 49);
                    Assert.AreEqual(
                        parameters.ParametersDict[ParameterType.
                                RadiusBaseCircle].MaxValue,
                        parameter.CurrentValue - 49);
                    break;

                case ParameterType.RadiusBaseCircle:
                    Assert.AreEqual(
                        parameters.ParametersDict[ParameterType.
                                RadiusInnerCircle].MinValue,
                        parameter.CurrentValue + 49);
                    break;

                case ParameterType.LampRadius:
                    double _innerRadius = parameters.
                        ParametersDict[ParameterType.
                        RadiusInnerCircle].CurrentValue;
                    double _lampRadius = parameters.
                        ParametersDict[ParameterType.
                        LampRadius].CurrentValue;
                    int _maxValue = (int)(_innerRadius * Math.PI /
                                          _lampRadius);

                    Assert.AreEqual(
                        parameters.ParametersDict[ParameterType.
                                LampsAmount].MaxValue,
                        _maxValue);
                    break;
            }
        }
    }
}