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
        private Dictionary<ParameterType, Parameter> parametersDict;

        public Dictionary<ParameterType, Parameter> ParametersDict
        {
            set { parametersDict = value; }
            get { return parametersDict; }
        }

        Parameters(Dictionary<ParameterType, Parameter> parametersDict)
        {
            this.ParametersDict = parametersDict;
        }

        Parameters() 
        {
            parametersDict.Add(ParameterType.RadiusOuterCircle, new Parameter(800, 400, 1000));
            parametersDict.Add(ParameterType.RadiusInnerCircle, new Parameter(700, 150, 750));
            parametersDict.Add(ParameterType.RadiusBaseCircle, new Parameter(100, 100, 100));
            parametersDict.Add(ParameterType.FoundationThickness, new Parameter(60, 40, 80));
            parametersDict.Add(ParameterType.LampsAmount, new Parameter(12, 0, 109));
            parametersDict.Add(ParameterType.LampRadius, new Parameter(20, 15, 25));
        }

        public void AssertParameter(ParameterType parameterType, Parameter parameter, double value)
        {
            Validator.AssertNumberIsInRange(value, parameter.MaxValue, parameter.MinValue);

            parameter.CurrentValue = value;
        }

        private void ChangeParametersRangeValues(ParameterType parameterType, Parameter parameter)
        {
            switch (parameterType) 
            {
                case ParameterType.RadiusOuterCircle:
                    this.ParametersDict[ParameterType.RadiusInnerCircle].MaxValue = parameter.CurrentValue - 50; 
                    break;

                case ParameterType.RadiusInnerCircle:
                    this.ParametersDict[ParameterType.RadiusOuterCircle].MinValue = parameter.CurrentValue + 50;
                    this.ParametersDict[ParameterType.RadiusBaseCircle].MaxValue = parameter.CurrentValue - 50;
                    break;

                case ParameterType.RadiusBaseCircle:
                    this.ParametersDict[ParameterType.RadiusInnerCircle].MinValue= parameter.CurrentValue + 50;
                    break;

                case ParameterType.LampRadius:
                    var _innerRadius = this.ParametersDict[ParameterType.RadiusInnerCircle].CurrentValue;
                    var _lampRadius = this.ParametersDict[ParameterType.LampRadius].CurrentValue;

                    int _maxValue = (int)(_innerRadius * Math.PI / _lampRadius);

                    this.ParametersDict[ParameterType.LampsAmount].MaxValue = _maxValue;
                    break;
            }
        }
    }
}
