namespace ChandelierPlugin.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Представляет набор параметров с соответствующими типами.
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Словарь, содержащий параметры с их типами.
        /// </summary>
        public Dictionary<ParameterType, Parameter> ParametersDict =
            new Dictionary<ParameterType, Parameter>();

        /// <summary>
        /// Отступ от возможных граничных параметров детали.
        /// </summary>
        private readonly double _borderOffset = 49;

        /// <summary>
        /// Инициализирует новый экземпляр класса Parameters со значениями
        /// параметров по умолчанию.
        /// </summary>
        public Parameters()
        {
            ParametersDict.Add(
                ParameterType.RadiusOuterCircle,
                new Parameter(800, 1000, 400));
            ParametersDict.Add(
                ParameterType.RadiusInnerCircle,
                new Parameter(700, 750, 150));
            ParametersDict.Add(
                ParameterType.RadiusBaseCircle,
                new Parameter(100, 100, 100));
            ParametersDict.Add(
                ParameterType.FoundationThickness,
                new Parameter(60, 80, 40));
            ParametersDict.Add(
                ParameterType.LampsAmount,
                new Parameter(12, 109, 1));
            ParametersDict.Add(
                ParameterType.LampRadius,
                new Parameter(20, 25, 15));
        }

        /// <summary>
        /// Проверяет и задает значение для указанного параметра, а затем
        /// обновляет диапазоны других параметров.
        /// </summary>
        /// <param name="parameterType">Тип параметра.</param>
        /// <param name="parameter">Экземпляр параметра.</param>
        /// <param name="value">Значение параметра для установки.</param>
        public void AssertParameter(
            ParameterType parameterType,
            Parameter parameter,
            double value)
        {
            Validator.AssertNumberIsInRange(
                value,
                parameter.MinValue,
                parameter.MaxValue);
            ParametersDict[parameterType].CurrentValue = value;
            ChangeParametersRangeValues(parameterType, parameter);
        }

        /// <summary>
        /// Изменяет значения диапазона других параметров в зависимости от
        /// изменения указанного параметра.
        /// </summary>
        /// <param name="parameterType">Тип параметра, который был изменен.</param>
        /// <param name="parameter">Измененный параметр.</param>
        public void ChangeParametersRangeValues(
            ParameterType parameterType,
            Parameter parameter)
        {
            switch (parameterType)
            {
                case ParameterType.RadiusOuterCircle:
                    ParametersDict[ParameterType.RadiusInnerCircle].
                        MaxValue = parameter.CurrentValue - _borderOffset;
                    break;

                case ParameterType.RadiusInnerCircle:
                    ParametersDict[ParameterType.RadiusOuterCircle].
                        MinValue = parameter.CurrentValue + _borderOffset;
                    ParametersDict[ParameterType.RadiusBaseCircle].
                        MaxValue = parameter.CurrentValue - _borderOffset;
                    break;

                case ParameterType.RadiusBaseCircle:
                    ParametersDict[ParameterType.RadiusInnerCircle].
                        MinValue = parameter.CurrentValue + _borderOffset;
                    break;

                case ParameterType.LampRadius:
                    double _innerRadius = ParametersDict[ParameterType.
                        RadiusInnerCircle].CurrentValue;
                    double _lampRadius = ParametersDict[ParameterType.
                        LampRadius].CurrentValue;
                    int _maxValue = (int)(_innerRadius * Math.PI /
                                          _lampRadius);

                    ParametersDict[ParameterType.LampsAmount].MaxValue =
                        _maxValue;
                    break;

                case ParameterType.FoundationThickness:
                    break;

                case ParameterType.LampsAmount:
                    break;

                default:
                    var message = "Введен некорректный тип параметра";
                    throw new ArgumentException(message);
            }
        }
    }
}