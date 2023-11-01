using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandelierPlugin.Model
{
    public class Parameters
    {
        private Dictionary<ParameterType, Parameter> _parametersDict;

        public Dictionary<ParameterType, Parameter> ParametersDict = new Dictionary<ParameterType, Parameter>();

        public Parameters(Dictionary<ParameterType, Parameter> parametersDict)
        {
            this.ParametersDict = parametersDict;
        }

        public Parameters() 
        {
            ParametersDict.Add(ParameterType.RadiusOuterCircle, new Parameter(800, 1000, 400));
            ParametersDict.Add(ParameterType.RadiusInnerCircle, new Parameter(700, 750, 150));
            ParametersDict.Add(ParameterType.RadiusBaseCircle, new Parameter(100, 100, 100));
            ParametersDict.Add(ParameterType.FoundationThickness, new Parameter(60, 80, 40));
            ParametersDict.Add(ParameterType.LampsAmount, new Parameter(12, 109, 0));
            ParametersDict.Add(ParameterType.LampRadius, new Parameter(20, 25, 15));
        }

        public void AssertParameter(ParameterType parameterType, Parameter parameter, double value)
        {
            Validator.AssertNumberIsInRange(value, parameter.MinValue, parameter.MaxValue);
            this.ParametersDict[parameterType].CurrentValue = value;
            this.ChangeParametersRangeValues(parameterType, parameter);
        }

        private void ChangeParametersRangeValues(ParameterType parameterType, Parameter parameter)
        {
            switch (parameterType) 
            {
                case ParameterType.RadiusOuterCircle:
                    this.ParametersDict[ParameterType.RadiusInnerCircle].MaxValue = parameter.CurrentValue - 49; 
                    break;

                case ParameterType.RadiusInnerCircle:
                    this.ParametersDict[ParameterType.RadiusOuterCircle].MinValue = parameter.CurrentValue + 49;
                    this.ParametersDict[ParameterType.RadiusBaseCircle].MaxValue = parameter.CurrentValue - 49;
                    break;

                case ParameterType.RadiusBaseCircle:
                    this.ParametersDict[ParameterType.RadiusInnerCircle].MinValue= parameter.CurrentValue + 49;
                    break;

                case ParameterType.LampRadius:
                    double _innerRadius = this.ParametersDict[ParameterType.RadiusInnerCircle].CurrentValue;
                    double _lampRadius = this.ParametersDict[ParameterType.LampRadius].CurrentValue;
                    int _maxValue = (int)(_innerRadius * Math.PI / _lampRadius);

                    this.ParametersDict[ParameterType.LampsAmount].MaxValue = _maxValue;
                    break;
            }
        }
    }
}
