﻿namespace ChandelierPlugin.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Представляет набор параметров с соответствующими типами.
    /// </summary>
    public class Parameters
    {
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
            ParametersDict = new Dictionary<ParameterType, Parameter>
            {
                {
                    ParameterType.RadiusOuterCircle,
                    new Parameter(800, 1000, 400)
                },
                {
                    ParameterType.RadiusInnerCircle,
                    new Parameter(700, 750, 150)
                },
                {
                    ParameterType.RadiusBaseCircle,
                    new Parameter(100, 100, 100)
                },
                {
                    ParameterType.FoundationThickness,
                    new Parameter(60, 80, 40)
                },
                {
                    ParameterType.LampsAmount,
                    new Parameter(12, 109, 1)
                },
                {
                    ParameterType.LampRadius,
                    new Parameter(20, 25, 15)
                },
                {
                    ParameterType.LayersAmount,
                    new Parameter(1, 5, 1)
                },
                {
                    ParameterType.ParameterMultiplier,
                    new Parameter(1, 1.5, 0.3)
                }
            };
        }

        /// <summary>
        /// Словарь, содержащий параметры с их типами.
        /// </summary>
        public Dictionary<ParameterType, Parameter> ParametersDict { get; set; }

        /// <summary>
        /// Получает словарь текущих значений параметров.
        /// </summary>
        /// <returns>Словарь, тип параметра - текущее значение параметра.</returns>
        public Dictionary<ParameterType, double> GetParametersCurrentValues()
        {
            var parametersCurrentValues = new Dictionary<ParameterType, double>();

            foreach (var item in ParametersDict)
            {
                parametersCurrentValues.Add(item.Key, item.Value.CurrentValue);
            }

            return parametersCurrentValues;
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
                    var _innerRadius = ParametersDict[ParameterType.
                        RadiusInnerCircle].CurrentValue;
                    var _lampRadius = ParametersDict[ParameterType.
                        LampRadius].CurrentValue;
                    var _maxValue = (int)(_innerRadius * Math.PI /
                                          _lampRadius);

                    ParametersDict[ParameterType.LampsAmount].MaxValue =
                        _maxValue;
                    break;

                case ParameterType.FoundationThickness:
                case ParameterType.LampsAmount:
                case ParameterType.LayersAmount:
                case ParameterType.ParameterMultiplier:
                    break;

                default:
                    var message = "Введен некорректный тип параметра";
                    throw new ArgumentException(message);
            }
        }
    }
}