using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChandelierPlugin.Model
{
    public class Parameter
    {
        public double CurrentValue { get; set; }
        public double MaxValue { get; set; }
        public double MinValue { get; set; }

        public Parameter(double currentValue, double maxValue, double minValue)
        {
            CurrentValue = currentValue;
            MaxValue = maxValue;
            MinValue = minValue;
        }
    }
}
